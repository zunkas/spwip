namespace SwedbankPay.Sdk.PaymentOrder;

public class PaymentOrderRequest
{
    public PaymentOrderRequest(Operation operation, Currency currency, Amount amount, Amount vatAmount, string description,
        string userAgent, Language language, string productName, Urls urls,
        PayeeInfo payeeInfo)
    {
        Operation = operation;
        Currency = currency;
        Amount = amount;
        VatAmount = vatAmount;
        Description = description;
        UserAgent = userAgent;
        Language = language;
        ProductName = productName; 
        Urls = urls;
        PayeeInfo = payeeInfo;
    }

    public Operation Operation { get; }
    public Currency Currency { get; }
    public Amount Amount { get; }
    public Amount VatAmount { get; }
    public string Description { get; }
    public string UserAgent { get; }
    public Language Language { get; }
    public string? Instrument { get; set; }
    public string ProductName { get; }
    public string? Implementation { get; set; }
    public Urls Urls { get; }
    public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public PayeeInfo PayeeInfo { get; }
    
    public Metadata? Metadata { get; set; }
}