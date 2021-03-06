﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsbSdk.Logistics
{

    public class Shipping
    {
        [JsonProperty("is_success")]
        public bool IsSuccess { get; set; }
    }

    public class LogisticsDummySendResponse
    {
        [JsonProperty("shipping")]
        public Shipping Shipping { get; set; }
    }

    public class JsbLogisticsDummySendResponse : JsbResponse
    {

        [JsonProperty("logistics_dummy_send_response")]
        public LogisticsDummySendResponse LogisticsDummySendResponse { get; set; }
    }

}
