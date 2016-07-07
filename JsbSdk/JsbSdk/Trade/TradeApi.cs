using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsbSdk.Trade
{
    /// <summary>
    /// Taobao trade API wrapper. This class corresponds to http://open.taobao.com/doc2/apiList.htm?spm=a219a.7629065.0.0.VRRQYY&cid=5.
    /// </summary>
    public class TradeApi : JsbWeb
    {
        public TradeApi(string accessKey, string secretKey) : base(accessKey, secretKey) { }

        public async Task<JsbTradesSoldGetResponse> TradesSoldGetAsync(string fields, DateTime? start_created = null, DateTime? end_created = null, TradeStatus? status = null, string buyer_nick = null, string type = null, string ext_type = null, RateStatus? rate_status = null, string tag = null, int page_no = 1, int page_size = 40, bool use_has_next = false)
        {
            var data = new Dictionary<string, string>();
            data["fields"] = fields;
            if (start_created != null)
                data["start_created"] = start_created.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (end_created != null)
                data["end_created"] = start_created.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (status != null)
                data["status"] = status.Value.ToString();
            if (buyer_nick != null)
                data["buyer_nick"] = buyer_nick;
            if (type != null)
                data["type"] = type;
            if (ext_type != null)
                data["ext_type"] = ext_type;
            if (rate_status != null)
                data["rate_status"] = rate_status.Value.ToString();
            if (tag != null)
                data["tag"] = tag;
            if (page_no != 1)
                data["page_no"] = page_no.ToString();
            if (page_size != 40)
                data["page_size"] = page_size.ToString();
            
            return await Task.Run(async () => JsonConvert.DeserializeObject<JsbTradesSoldGetResponse>(await base.FetchAsync(new Uri("trade/TradesSoldGetRequest", UriKind.Relative), data)));
        }

        public async Task<JsbTradeCloseResponse> TradeClose(string tid, string close_reason)
        {
            var data = new Dictionary<string, string>();
            data["tid"] = tid;
            data["close_reason"] = close_reason;

            return await Task.Run(async () => JsonConvert.DeserializeObject<JsbTradeCloseResponse>(await base.FetchAsync(new Uri("trade/TradeCloseRequest", UriKind.Relative), data)));
        }
    }

    public enum TradeStatus
    {
        WAIT_BUYER_PAY,
        WAIT_SELLER_SEND_GOODS,
        SELLER_CONSIGNED_PART,
        WAIT_BUYER_CONFIRM_GOODS,
        TRADE_BUYER_SIGNED,
        TRADE_FINISHED,
        TRADE_CLOSED,
        TRADE_CLOSED_BY_TAOBAO,
        TRADE_NO_CREATE_PAY,
        WAIT_PRE_AUTH_CONFIRM,
        PAY_PENDING,
        ALL_WAIT_PAY,
        ALL_CLOSED,
    }

    public enum RateStatus
    {
        RATE_UNBUYER,
        RATE_UNSELLER,
        RATE_BUYER_UNSELLER,
        RATE_UNBUYER_SELLER,
        RATE_BUYER_SELLER,
    }
}
