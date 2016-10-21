using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsbSdk;

namespace JsbSdkTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test()
        {
            var jsbWeb = new JsbWeb("asdoooooooooooooooooooooooooohfiohdoassssssssssswwwwwwwwwwwwwwwwww", "1234567");
            var result = jsbWeb.Fetch(jsbWeb.SignTestUri, "PUT");
            Assert.AreEqual(result, "{\"error_response\":{\"code\":\"success\",\"msg\":\"success\",\"sub_code\":\"\",\"sub_msg\":\"signature match\",\"request_id\":\"\"}}");
        }

        [TestMethod]
        public void GetOrderTest()
        {
            var jsbWeb = new JsbWeb("038753ca8df75ea168a41d86a7693f26e89d8070994b3e130b89c345180056ce", "14321efb5bc53a57fa8ac4c261de31ce2dc5e8f8ce207f4fab721007c40d9977");
            var result = jsbWeb.Trades.TradesSoldGetAsync("tid,payment,orders,receiver_name,receiver_state,receiver_address,receiver_zip,receiver_mobile,receiver_phone,received_payment,receiver_country,receiver_town,title,created,buyer_nick,receiver_city,receiver_district,orders", DateTime.Now.AddDays(-1), null, JsbSdk.Trade.TradeStatus.WAIT_SELLER_SEND_GOODS).Result;
            Assert.IsTrue(result.ErrorResponse == null);
        }

        [TestMethod]
        public void SendOrderTest()
        {
            var jsbWeb = new JsbWeb("038753ca8df75ea168a41d86a7693f26e89d8070994b3e130b89c345180056ce", "14321efb5bc53a57fa8ac4c261de31ce2dc5e8f8ce207f4fab721007c40d9977");
            var result = jsbWeb.Logistics.LogisticsDummySendAsync(1657509384533278).Result;
            Assert.IsTrue(result.ErrorResponse == null);
        }
    }
}
