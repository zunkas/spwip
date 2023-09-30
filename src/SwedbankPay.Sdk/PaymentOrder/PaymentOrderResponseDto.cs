namespace SwedbankPay.Sdk.PaymentOrder;


public class PaymentOrderResponseDto
{
    public PaymentOrderResponseItemDto PaymentOrder { get; set; }
    public OperationsResponseDto[] Operations { get; set; }
}

public class PaymentOrderResponseItemDto
{
    public string Id { get; set; }
    public string Created { get; set; }
    public string Updated { get; set; }
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

public class PayerResponseDto
{
    public string id { get; set; }
}

public class OrderItemResponseDto
{
    public string id { get; set; }
}

public class HistoryResponseDto
{
    public string id { get; set; }
}

public class FailedResponseDto
{
    public string id { get; set; }
}

public class AbortedResponseDto
{
    public string id { get; set; }
}

public class PaidResponseDto
{
    public string id { get; set; }
}

public class CancelledResponseDto
{
    public string id { get; set; }
}

public class FinancialTransactionsResponseDto
{
    public string id { get; set; }
}

public class FailedAttemptsResponseDto
{
    public string id { get; set; }
}

public class MetadataResponseDto
{
    public string id { get; set; }
}

public class OperationsResponseDto
{
    public string Method { get; set; }
    public string Href { get; set; }
    public string Rel { get; set; }
    public string ContentType { get; set; }
}

