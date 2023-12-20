using SwedbankPay.Sdk.PaymentOrder.Address;

namespace SwedbankPay.Sdk.PaymentOrder.Payer;

/// <summary>
/// Detailed information about a payer for a payment order.
/// </summary>
public record Payer
{
    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public EmailAddress? Email { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public string? Msisdn { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public string? WorkPhoneNumber { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public string? HomePhoneNumber { get; set; }

    /// <summary>
    /// Payers billing address for this payment order.
    /// </summary>
    public BillingAddress? BillingAddress { get; set; }

    /// <summary>
    /// Payers shipping address for this payment order.
    /// </summary>
    public PickUpAddress? ShippingAddress { get; set; }
}