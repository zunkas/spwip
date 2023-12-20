using SwedbankPay.Sdk.PaymentOrder.Address;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Address;

internal record PickUpAddressDto
{
    public PickUpAddressDto(PickUpAddress? riskIndicatorPickUpAddress)
    {
        Name = riskIndicatorPickUpAddress?.Name ?? "";
        StreetAddress = riskIndicatorPickUpAddress?.StreetAddress ?? "";
        CoAddress = riskIndicatorPickUpAddress?.CoAddress ?? "";
        City = riskIndicatorPickUpAddress?.City ?? "";
        ZipCode = riskIndicatorPickUpAddress?.ZipCode ?? "";
        CountryCode = riskIndicatorPickUpAddress?.CountryCode ?? "";
    }

    public string Name { get; }
    
    public string StreetAddress { get; }
    
    public string CoAddress { get; }
    
    public string City { get; }

    public string ZipCode { get; }

    public string CountryCode { get; }

}