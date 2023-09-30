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
}

public class Urls
{
    public Urls(IList<Uri> hostUrls, Uri completeUrl, Uri cancelUrl, Uri callbackUrl)
    {
        HostUrls = hostUrls;
        CompleteUrl = completeUrl;
        CancelUrl = cancelUrl;
        CallbackUrl = callbackUrl;
    }

    public IList<Uri> HostUrls { get; }
    public Uri? PaymentUrl { get; set; }
    public Uri CompleteUrl { get; }
    public Uri CancelUrl { get; }
    public Uri CallbackUrl { get; }
    public Uri? LogoUrl { get; set; }
}

public class OrderItem
{
    public OrderItem(string reference, string name, OrderItemType type, string @class, int quantity, string quantityUnit, Amount unitPrice, int vatPercent, Amount amount, Amount vatAmount)
    {
        Reference = reference;
        Name = name;
        Type = type;
        Class = @class;
        Quantity = quantity;
        QuantityUnit = quantityUnit;
        UnitPrice = unitPrice;
        VatPercent = vatPercent;
        Amount = amount;
        VatAmount = vatAmount;
    }

    public string Reference { get; }
    public string Name { get; }
    public OrderItemType Type { get; }
    public string Class { get; }
    public string? ItemUrl { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string? DiscountDescription { get; set; }
    public int Quantity { get; }
    public string QuantityUnit { get; }
    public Amount UnitPrice { get; }
    public int? DiscountPrice { get; set; }
    public int VatPercent { get; }
    public Amount Amount { get; }
    public Amount VatAmount { get; }
}

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