namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Cancel;

public record PaymentOrderCancelRequestDetail
{
    public string Description { get; }
    public string PayeeReference { get; }

    public PaymentOrderCancelRequestDetail(string description, string payeeReference)
    {
        Description = description;
        PayeeReference = payeeReference;
    }
}