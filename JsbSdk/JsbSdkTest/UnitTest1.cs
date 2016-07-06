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
            var result = jsbWeb.FetchAsync(jsbWeb.SignTestUri).Result;
            Assert.AreEqual(result, "{\"error_response\":{\"code\":\"success\",\"msg\":\"success\",\"sub_code\":\"\",\"sub_msg\":\"signature match\",\"request_id\":\"\"}}");
        }
    }
}
