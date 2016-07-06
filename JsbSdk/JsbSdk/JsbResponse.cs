using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsbSdk
{
    public class JsbResponse
    {
        [JsonProperty("error_response")]
        public ErrorResponse ErrorResponse { get; set; }
    }

    public class ErrorResponse
    {
        [JsonProperty("code")]
        public JsbErrorCodes Code { get; set; }
        [JsonProperty("msg")]
        public string Message { get; set; }
        [JsonProperty("sub_code")]
        public string SubCode { get; set; }
        [JsonProperty("sub_msg")]
        public string SubMessage { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }

    public enum JsbErrorCodes
    {
        SignatureDoesNotMatch
    }
}
