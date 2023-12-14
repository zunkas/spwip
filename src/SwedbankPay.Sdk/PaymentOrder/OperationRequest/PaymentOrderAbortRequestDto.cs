namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest;

internal record PaymentOrderAbortRequestDto
{
    internal PaymentOrderAbortRequestDto(PaymentOrderAbortRequest payload)
    {
        PaymentOrder = new PaymentOrderAbortRequestDetailDto(payload.PaymentOrder);
    }

    public PaymentOrderAbortRequestDetailDto PaymentOrder { get; }
}