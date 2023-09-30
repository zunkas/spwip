namespace SwedbankPay.Sdk;

public class PayeeInfo
{
    public PayeeInfo(string payeeId, string payeeReference)
    {
        PayeeId = payeeId;
        PayeeReference = payeeReference;
    }

    public string PayeeId { get; }
    public string PayeeReference { get; }
    public string? PayeeName { get; set; }
    public string? OrderReference { get; set; }
}