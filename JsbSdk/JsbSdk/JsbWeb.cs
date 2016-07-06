using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JsbSdk
{
    public class JsbWeb
    {
        public Uri JsbRestBaseUri { get; set; } = new Uri("http://120.55.113.176/JSB/rest/");
        public Uri SignTestUri => new Uri(JsbRestBaseUri, "sign_test");

        private string accessKey;
        private string secretKey;

        public JsbWeb(string accessKey, string secretKey)
        {
            this.accessKey = accessKey;
            this.secretKey = secretKey;
        }

        public async Task<string> FetchAsync(Uri uri, string verb, Dictionary<string, string> parameters = null)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");

            using (var response = await Request(uri, verb, parameters))
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public Task<string> FetchAsync(Uri uri, Dictionary<string, string> parameters = null)
        {
            return FetchAsync(uri, "GET", parameters);
        }

        public string Fetch(Uri uri, string verb, Dictionary<string, string> parameters = null)
        {
            return FetchAsync(uri, verb, parameters).Result;
        }

        public string Fetch(Uri uri, Dictionary<string, string> parameters = null)
        {
            return FetchAsync(uri, "GET", parameters).Result;
        }

        public async Task<HttpWebResponse> Request(Uri uri, string verb, Dictionary<string, string> paramters = null)
        {
            if (!uri.IsAbsoluteUri)
                uri = new Uri(JsbRestBaseUri, uri);
            verb = verb.ToUpper();
            string requestId = Guid.NewGuid().ToString();
            string timeStamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss+0000");

            if (paramters != null)
            {
                if (!string.IsNullOrEmpty(uri.Query))
                    throw new InvalidOperationException("Uri cannnot contain a query when no parameters are specified.");
                uri = new Uri(uri.ToString() + "?" + string.Join("&", paramters.Select(p => WebUtility.UrlEncode(p.Key) + "=" + WebUtility.UrlEncode(p.Value))));
            }

            var request = WebRequest.CreateHttp(uri);
            request.Method = verb;
            request.Headers["x-jsb-sdk-req-timestamp"] = timeStamp;
            request.Headers["x-jsb-sdk-req-uuid"] = requestId;
            request.Headers[HttpRequestHeader.Authorization] = GetAuthorizationHeader("PUT", uri.ToString(), timeStamp, requestId);

            var response = await request.GetResponseAsync() as HttpWebResponse;
            return response;
        }


        private string GetAuthorizationHeader(string method, string uri, string timestamp, string requestId)
        {
            //Build a string containing essential information used to identify a request. It will not be sent to the server but instead, used to generate a digest. The generated digest will be keyed-hashed and sent to the server.
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(method.ToUpper());
            stringBuilder.Append("\n");
            stringBuilder.Append(WebUtility.UrlEncode(uri).ToLower());
            stringBuilder.Append("\n");
            stringBuilder.Append("x-jsb-sdk-req-timestamp:");
            stringBuilder.Append(timestamp);
            stringBuilder.Append("\n");
            stringBuilder.Append("x-jsb-sdk-req-uuid:");
            stringBuilder.Append(requestId.ToLower());
            stringBuilder.Append("\n");

            var stringToSign = stringBuilder.ToString();
            var stringToSignUtf8 = Encoding.UTF8.GetBytes(stringToSign);
            //Get SHA-1 Algroism
            var sha1Algorism = new Sha1Digest();
            //Create a Digest of stringToSign using SHA-1
            sha1Algorism.BlockUpdate(stringToSignUtf8, 0, stringToSignUtf8.Length);
            var Sha1DigestOfStringToSign = new byte[sha1Algorism.GetDigestSize()];
            sha1Algorism.DoFinal(Sha1DigestOfStringToSign, 0);
            var Sha1DigestHexStringOfStringToSign = BitConverter.ToString(Sha1DigestOfStringToSign).Replace("-", "").ToLower();
            //Generate a hash key from JSB's secret key and request id. The hash key is the result of HMac SHA-256 algorism where request id is the string to hash and secret key is the hash key.
            var hashKey = ComputeHMacSHA256(requestId, Encoding.UTF8.GetBytes("JSB4" + this.secretKey));
            //Using the generated hash key above to keyed-hash Sha1DigestHexStringOfStringToSign. This will be used the signature in the authorization header.
            var signature = ComputeHMacSHA256(Sha1DigestHexStringOfStringToSign, hashKey);
            var signatureHex = BitConverter.ToString(signature).Replace("-", "").ToLower();

            //Build the authorization header string.
            stringBuilder = new StringBuilder();
            stringBuilder.Append("Credential=" + this.accessKey);
            stringBuilder.Append(",SignedHeaders=x-jsb-sdk-req-timestamp;x-jsb-sdk-req-uuid,Signature=");
            stringBuilder.Append(signatureHex);
            return stringBuilder.ToString();
        }

        private byte[] ComputeHMacSHA256(string data, byte[] key)
        {
            var hmacSha256Algorism = new HMac(new Sha256Digest());

            hmacSha256Algorism.Init(new KeyParameter(key));
            var dataUtf8 = Encoding.UTF8.GetBytes(data);
            hmacSha256Algorism.BlockUpdate(dataUtf8, 0, dataUtf8.Length);
            var result = new byte[hmacSha256Algorism.GetUnderlyingDigest().GetDigestSize()];
            hmacSha256Algorism.DoFinal(result, 0);
            return result;
        }
    }
}
