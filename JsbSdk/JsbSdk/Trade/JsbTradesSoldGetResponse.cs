﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsbSdk.Trade
{
    public class Order
    {
        [JsonProperty("adjust_fee")]
        public string AdjustFee { get; set; }

        [JsonProperty("buyer_rate")]
        public bool BuyerRate { get; set; }

        [JsonProperty("cid")]
        public int Cid { get; set; }

        [JsonProperty("discount_fee")]
        public string DiscountFee { get; set; }

        [JsonProperty("is_daixiao")]
        public bool IsDaixiao { get; set; }

        [JsonProperty("num")]
        public int Num { get; set; }

        [JsonProperty("num_iid")]
        public object NumIid { get; set; }

        [JsonProperty("oid")]
        public object Oid { get; set; }

        [JsonProperty("outer_iid")]
        public string OuterIid { get; set; }

        [JsonProperty("payment")]
        public string Payment { get; set; }

        [JsonProperty("pic_path")]
        public string PicPath { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("refund_status")]
        public string RefundStatus { get; set; }

        [JsonProperty("seller_rate")]
        public bool SellerRate { get; set; }

        [JsonProperty("seller_type")]
        public string SellerType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("total_fee")]
        public string TotalFee { get; set; }
    }

    public class Orders
    {

        [JsonProperty("order")]
        public Order[] Order { get; set; }
    }

    public class Trade
    {
        [JsonProperty("seller_nick")]
        public string SellerNick { get; set; }

        [JsonProperty("pic_path")]
        public string PicPath { get; set; }

        [JsonProperty("payment")]
        public string Payment { get; set; }

        [JsonProperty("seller_rate")]
        public bool SellerRate { get; set; }

        [JsonProperty("post_fee")]
        public string PostFee { get; set; }

        [JsonProperty("receiver_name")]
        public string ReceiverName { get; set; }

        [JsonProperty("receiver_state")]
        public string ReceiverState { get; set; }

        [JsonProperty("receiver_address")]
        public string ReceiverAddress { get; set; }

        [JsonProperty("receiver_zip")]
        public string ReceiverZip { get; set; }

        [JsonProperty("receiver_mobile")]
        public string ReceiverMobile { get; set; }

        [JsonProperty("receiver_phone")]
        public string ReceiverPhone { get; set; }

        [JsonProperty("consign_time")]
        public DateTime? ConsignTime { get; set; }

        [JsonProperty("received_payment")]
        public string ReceivedPayment { get; set; }

        [JsonProperty("receiver_country")]
        public string ReceiverCountry { get; set; }

        [JsonProperty("receiver_town")]
        public string ReceiverTown { get; set; }

        [JsonProperty("order_tax_fee")]
        public string OrderTaxFee { get; set; }

        [JsonProperty("shop_pick")]
        public string ShopPick { get; set; }

        [JsonProperty("tid")]
        public long Tid { get; set; }

        [JsonProperty("num")]
        public int Num { get; set; }

        [JsonProperty("num_iid")]
        public int NumIid { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Don't get confused. This is the name of the shop not the order.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("discount_fee")]
        public string DiscountFee { get; set; }

        [JsonProperty("total_fee")]
        public string TotalFee { get; set; }

        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        [JsonProperty("pay_time")]
        public DateTime? PayTime { get; set; }

        [JsonProperty("modified")]
        public DateTime? Modified { get; set; }

        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("seller_flag")]
        public int SellerFlag { get; set; }

        [JsonProperty("buyer_nick")]
        public string BuyerNick { get; set; }

        [JsonProperty("has_buyer_message")]
        public bool HasBuyerMessage { get; set; }

        [JsonProperty("credit_card_fee")]
        public string CreditCardFee { get; set; }

        [JsonProperty("step_trade_status")]
        public string StepTradeStatus { get; set; }

        [JsonProperty("step_paid_fee")]
        public string StepPaidFee { get; set; }

        [JsonProperty("mark_desc")]
        public string MarkDesc { get; set; }

        [JsonProperty("shipping_type")]
        public string ShippingType { get; set; }

        [JsonProperty("adjust_fee")]
        public string AdjustFee { get; set; }

        [JsonProperty("trade_from")]
        public string TradeFrom { get; set; }

        [JsonProperty("service_orders")]
        public JArray ServiceOrders { get; set; }

        [JsonProperty("buyer_rate")]
        public bool BuyerRate { get; set; }

        [JsonProperty("receiver_city")]
        public string ReceiverCity { get; set; }

        [JsonProperty("receiver_district")]
        public string ReceiverDistrict { get; set; }

        [JsonProperty("orders")]
        public Orders Orders { get; set; }

        [JsonProperty("rx_audit_status")]
        public string RxAuditStatus { get; set; }

        [JsonProperty("post_gate_declare")]
        public bool PostGateDeclare { get; set; }

        [JsonProperty("cross_bonded_declare")]
        public bool CrossBondedDeclare { get; set; }
    }

    public class Trades
    {
        [JsonProperty("trade")]
        public Trade[] Trade { get; set; }
    }

    public class TradesSoldGetResponse
    {
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("trades")]
        public Trades Trades { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("has_next")]
        public bool HasNext { get; set; }
    }

    public class JsbTradesSoldGetResponse : JsbResponse
    {
        [JsonProperty("trades_sold_get_response")]
        public TradesSoldGetResponse TradesSoldGetResponse { get; set; }
    }

}
