using SwedbankPay.Sdk.PaymentOrder.Payer;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record PayerResponse : Identifiable, IPayerResponse
{
    public IDevice? Device { get; }
    public string? Reference { get; }
    public string? Name { get; }
    public EmailAddress? Email { get; }
    public Msisdn? Msisdn { get; }
    public Dictionary<string, string>? HashedFields { get; }
    
    internal PayerResponse(PayerResponseDto dto) : base(dto.Id)
    {
        Device = dto.Device?.Map();
        Reference = dto.Reference;
        Name = dto.Name;
        Email = new EmailAddress(dto.Email ?? "");
        Msisdn = new Msisdn(dto.Msisdn ?? "");
        HashedFields = dto.HashedFields;
    }
}