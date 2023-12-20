using SwedbankPay.Sdk.PaymentOrder.Address;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Address;

internal record BillingAddressDto
{
    public BillingAddressDto(BillingAddress? payerBillingAddress)
    {
        FirstName = payerBillingAddress?.FirstName ?? "";
        LastName = payerBillingAddress?.LastName ?? "";
        Email = payerBillingAddress?.Email?.ToString() ?? "";
        Msisdn = payerBillingAddress?.Msisdn ?? "";
        StreetAddress = payerBillingAddress?.StreetAddress ?? "";
        CoAddress = payerBillingAddress?.CoAddress ?? "";
        City = payerBillingAddress?.City ?? "";
        ZipCode = payerBillingAddress?.ZipCode ?? "";
        CountryCode = payerBillingAddress?.CountryCode ?? "";
    }

    public string FirstName { get; }

    public string LastName { get; }
    
    public string Email { get; }

    public string Msisdn { get; }
    
    public string? StreetAddress { get; }
    
    public string? CoAddress { get; }
    
    public string City { get; }

    public string ZipCode { get; }

    public string CountryCode { get; }
}