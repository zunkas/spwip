namespace SwedbankPay.Sdk.PaymentOrder;

internal class PaymentOrderResponse : IPaymentOrderResponse
{
    internal PaymentOrderResponse(PaymentOrderResponseDto paymentOrderResponseDto, HttpClient httpClient)
    {
        PaymentOrder = new PaymentOrder(paymentOrderResponseDto.PaymentOrder);

        var httpOperations = new OperationList();
        foreach (var item in paymentOrderResponseDto.Operations)
        {
            var rel = new LinkRelation(item.Rel);
            var href = new Uri(item.Href, UriKind.RelativeOrAbsolute);
            httpOperations.Add(new HttpOperation(href, rel, item.Method, item.ContentType));
        }

        
        Operations = new PaymentOrderOperations(httpOperations, httpClient);
    }

    public IPaymentOrder PaymentOrder { get; }
    
    public IPaymentOrderOperations Operations { get; }
}