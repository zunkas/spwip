namespace SwedbankPay.Sdk;

public class OrderItem
{
    public OrderItem(string reference, string name, OrderItemType type, string @class, int quantity,
        string quantityUnit, Amount unitPrice, int vatPercent, Amount amount, Amount vatAmount)
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