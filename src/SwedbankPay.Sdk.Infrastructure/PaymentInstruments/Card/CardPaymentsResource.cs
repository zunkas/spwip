﻿using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentsResource : ResourceBase, ICardResource
    {
        public CardPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ICardPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.All)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Uri url = id.GetUrlWithQueryString(paymentExpand);

            var cardPaymentResponseDto = await HttpClient.GetAsJsonAsync<CardPaymentResponseDto>(url);
            return new CardPaymentResponse(cardPaymentResponseDto, HttpClient);
        }


        public async Task<ICardPaymentResponse> Create(CardPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.All)
        {
            var url = new Uri("/psp/creditcard/payments", UriKind.Relative).GetUrlWithQueryString(paymentExpand);

            var cardPaymentResponseDto = await HttpClient.PostAsJsonAsync<CardPaymentResponseDto>(url.GetUrlWithQueryString(paymentExpand), paymentRequest);
            return new CardPaymentResponse(cardPaymentResponseDto, HttpClient);
        }
    }
}
