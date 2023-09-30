namespace SwedbankPay.Sdk.PaymentOrder;

internal class PaymentOrderResponseDto
{
    public PaymentOrderResponseItemDto PaymentOrder { get; set; }
    public OperationsResponseDto[] Operations { get; set; }
}

internal class PaymentOrderResponseItemDto
{
    public string Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Operation { get; set; }
    public string Status { get; set; }
    public string Currency { get; set; }
    public long VatAmount { get; set; }
    public long Amount { get; set; }
    public string Description { get; set; }
    public string InitiatingSystemUserAgent { get; set; }
    public string Language { get; set; }
    public string[] AvailableInstruments { get; set; }
    public string Implementation { get; set; }
    public bool InstrumentMode { get; set; }
    public bool GuestMode { get; set; }
    public PayerResponseDto Payer { get; set; }
    public OrderItemResponseDto OrderItems { get; set; }
    public HistoryResponseDto History { get; set; }
    public FailedResponseDto Failed { get; set; }
    public AbortedResponseDto Aborted { get; set; }
    public PaidResponseDto Paid { get; set; }
    public CancelledResponseDto Cancelled { get; set; }
    public FinancialTransactionsResponseDto FinancialTransactions { get; set; }
    public FailedAttemptsResponseDto FailedAttempts { get; set; }
    public MetadataResponseDto Metadata { get; set; }
}

internal class PayerResponseDto : IdentifiableDto
{
    internal PayerResponseDto(string id) : base(id)
    {
    }
}

internal class OrderItemResponseDto : IdentifiableDto
{
    internal OrderItemResponseDto(string id) : base(id)
    {
    }
}

internal class HistoryResponseDto : IdentifiableDto
{
    internal HistoryResponseDto(string id) : base(id)
    {
    }
}

internal class FailedResponseDto : IdentifiableDto
{
    internal FailedResponseDto(string id) : base(id)
    {
    }
}

internal class AbortedResponseDto : IdentifiableDto
{
    internal AbortedResponseDto(string id) : base(id)
    {
    }
}

internal class PaidResponseDto: IdentifiableDto
{
    internal PaidResponseDto(string id) : base(id)
    {
    }
}

internal class CancelledResponseDto: IdentifiableDto
{
    internal CancelledResponseDto(string id) : base(id)
    {
    }
}

internal class FinancialTransactionsResponseDto : IdentifiableDto
{
    internal FinancialTransactionsResponseDto(string id) : base(id)
    {
    }
}

internal class FailedAttemptsResponseDto : IdentifiableDto
{
    internal FailedAttemptsResponseDto(string id) : base(id)
    {
    }
}

internal class MetadataResponseDto : IdentifiableDto
{
    internal MetadataResponseDto(string id) : base(id)
    {
    }
}

public class OperationsResponseDto
{
    public string Method { get; set; }
    public string Href { get; set; }
    public string Rel { get; set; }
    public string ContentType { get; set; }
}