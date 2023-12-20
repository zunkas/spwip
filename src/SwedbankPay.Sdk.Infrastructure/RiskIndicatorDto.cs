using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Address;

namespace SwedbankPay.Sdk.Infrastructure;

internal record RiskIndicatorDto
{
    public RiskIndicatorDto(RiskIndicator riskIndicator)
    {
        DeliveryEmailAddress = riskIndicator.DeliveryEmailAddress?.ToString() ?? "";
        DeliveryTimeFrameIndicator = riskIndicator.DeliveryTimeFrameIndicator?.Value ??
                                     Sdk.DeliveryTimeFrameIndicator.ElectronicDelivery.ToString();
        PreOrderDate = riskIndicator.PreOrderDate;
        PreOrderPurchaseIndicator = riskIndicator.PreOrderPurchaseIndicator?.Value ??
                                    Sdk.PreOrderPurchaseIndicator.FutureAvailability.ToString();
        ShipIndicator = riskIndicator.ShipIndicator?.Value ?? Sdk.ShipIndicator.Other.ToString();
        GiftCardPurchase = riskIndicator.GiftCardPurchase;
        ReOrderPurchaseIndicator = riskIndicator.ReOrderPurchaseIndicator?.Value ??
                                   Sdk.ReOrderPurchaseIndicator.FutureAvailability.ToString();
        PickUpAddress = new PickUpAddressDto(riskIndicator.PickUpAddress);
    }
    
    public string DeliveryEmailAddress { get; }
    
    public string DeliveryTimeFrameIndicator { get; }
    
    public DateTime PreOrderDate { get; }

    public string PreOrderPurchaseIndicator { get; }
    
    public string ShipIndicator { get; }

    public bool GiftCardPurchase { get; }

    public string ReOrderPurchaseIndicator { get; }

    public PickUpAddressDto? PickUpAddress { get; }
}