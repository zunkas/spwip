using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Address;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record PayerDto
{
    public PayerDto(Sdk.PaymentOrder.Payer.Payer payer)
    {
        FirstName = payer.FirstName;
        LastName = payer.LastName;
        PayerReference = payer.PayerReference;
        Email = payer.Email?.ToString();
        Msisdn = payer.Msisdn?.ToString();
        WorkPhoneNumber = payer.WorkPhoneNumber?.ToString();
        HomePhoneNumber = payer.HomePhoneNumber?.ToString();
        BillingAddress = new AddressDto(payer.BillingAddress);
        ShippingAddress = new AddressDto(payer.ShippingAddress);
    }

    public string? FirstName { get; }
    
    public string? LastName { get; }
    
    public string? PayerReference { get; }
    
    public string? Email { get; }

    public string? Msisdn { get; }

    public string? WorkPhoneNumber { get; }
    
    public string? HomePhoneNumber { get; }
    
    public AddressDto? BillingAddress { get; }
    
    public AddressDto? ShippingAddress { get; }
}