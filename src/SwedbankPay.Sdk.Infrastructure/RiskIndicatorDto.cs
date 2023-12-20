using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Address;

namespace SwedbankPay.Sdk.Infrastructure;

internal record RiskIndicatorDto
{
    private const string ThreeDSecureDateTimeString = "yyyyMMdd";

    public RiskIndicatorDto(RiskIndicator riskIndicator)
    {
        DeliveryEmailAddress = riskIndicator.DeliveryEmailAddress?.ToString();
        DeliveryTimeFrameIndicator = riskIndicator.DeliveryTimeFrameIndicator?.Value;
        PreOrderDate = riskIndicator.PreOrderDate.ToString(ThreeDSecureDateTimeString);
        PreOrderPurchaseIndicator = riskIndicator.PreOrderPurchaseIndicator?.Value;
        ShipIndicator = riskIndicator.ShipIndicator?.Value;
        GiftCardPurchase = riskIndicator.GiftCardPurchase;
        ReOrderPurchaseIndicator = riskIndicator.ReOrderPurchaseIndicator?.Value;
        PickUpAddress = new AddressDto(riskIndicator.PickUpAddress);
    }
    
    public string? DeliveryEmailAddress { get; }
    
    public string? DeliveryTimeFrameIndicator { get; }
    
    public string? PreOrderDate { get; }

    public string? PreOrderPurchaseIndicator { get; }
    
    public string? ShipIndicator { get; }

    public bool? GiftCardPurchase { get; }

    public string? ReOrderPurchaseIndicator { get; }

    public AddressDto? PickUpAddress { get; }
}