using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Address;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record PayerDto
{
    public PayerDto(Sdk.PaymentOrder.Payer.Payer payer)
    {
        Email = payer.Email?.ToString() ?? "";
        Msisdn = payer.Msisdn ?? "";
        WorkPhoneNumber = payer.WorkPhoneNumber ?? "";
        HomePhoneNumber = payer.HomePhoneNumber ?? "";
        BillingAddress = new BillingAddressDto(payer.BillingAddress);
        ShippingAddress = new PickUpAddressDto(payer.ShippingAddress);
    }
    
    public string Email { get; }

    public string Msisdn { get; }

    public string WorkPhoneNumber { get; }
    
    public string HomePhoneNumber { get; }
    
    public BillingAddressDto BillingAddress { get; }
    
    public PickUpAddressDto ShippingAddress { get; }
}