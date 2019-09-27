﻿namespace SwedbankPay.Client.Models.Vipps.PaymentAPI.Request
{
    using System.Collections.Generic;
    using SwedbankPay.Client.Models.Common;

    public class PaymentRequest
    {
        public PaymentRequest(string useragent, string description, string payerReference, string payeeReference, params Price[] prices)
        {
            UserAgent = useragent;
            Description = description;
            if(prices != null)
                Prices.AddRange(prices);
            
            PayerReference = payerReference;
            PayeeInfo.PayeeReference = payeeReference;
        }

        public string Operation { get; set; } = "Purchase";
        public string Intent { get; set; } = "Authorization";

        public string Currency { get; set; } = "NOK";

        public List<Price> Prices { get; set; } = new List<Price>();

        public string Description { get; set; }

        public string PayerReference { get; set; } 

        public string UserAgent { get; set; } 

        public string Language { get; set; } = "nb-NO";

        public CallBackUrls Urls { get; } = new CallBackUrls();

        public PayeeInfo PayeeInfo { get; } = new PayeeInfo();

        public PrefillInfo PrefillInfo { get; } = new PrefillInfo();

        public bool GeneratePaymentToken { get; set; } = false;
        
        public string PaymentToken { get; set; }
        
        public long Amount { get; set; }
        
        public long VatAmount { get; set; }
    }
}