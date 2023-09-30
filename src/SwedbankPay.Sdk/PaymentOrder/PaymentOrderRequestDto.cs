namespace SwedbankPay.Sdk.PaymentOrder;

internal class PaymentOrderRequestDto
{
    internal PaymentOrderRequestDto(PaymentOrderRequest paymentOrderRequest)
    {
        PaymentOrder = new PaymentOrderDto(paymentOrderRequest);
    }

    public PaymentOrderDto PaymentOrder { get; set; }
}


