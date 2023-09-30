namespace SwedbankPay.Sdk.PaymentOrder;

public class PaymentOrderResponse
{
    internal PaymentOrderResponse(PaymentOrderResponseDto paymentOrderResponseDto, HttpClient httpClient)
    {
        PaymentOrder = new PaymentOrder(paymentOrderResponseDto.PaymentOrder);
        Operations = paymentOrderResponseDto.Operations.Select(x => new Operations(x)).ToArray();
    }

    public PaymentOrder PaymentOrder { get; }
    public Operations[] Operations { get; }
}


public class PaymentOrder
{
    internal PaymentOrder(PaymentOrderResponseItemDto paymentOrderResponseItemDto)
    {
        Id = paymentOrderResponseItemDto.Id;
        Created = paymentOrderResponseItemDto.Created;
        Updated = paymentOrderResponseItemDto.Updated;
        Operation = paymentOrderResponseItemDto.Operation;
        Status = paymentOrderResponseItemDto.Status;
        Currency = paymentOrderResponseItemDto.Currency;
        VatAmount = new Amount(paymentOrderResponseItemDto.VatAmount);
        Amount = new Amount(paymentOrderResponseItemDto.Amount);
        Description = paymentOrderResponseItemDto.Description;
        InitiatingSystemUserAgent = paymentOrderResponseItemDto.InitiatingSystemUserAgent;
        Language = new Language(paymentOrderResponseItemDto.Language);
        AvailableInstruments = paymentOrderResponseItemDto.AvailableInstruments;
        Implementation = paymentOrderResponseItemDto.Implementation;
        InstrumentMode = paymentOrderResponseItemDto.InstrumentMode;
        GuestMode = paymentOrderResponseItemDto.GuestMode;
        Payer = new PayerResponse(paymentOrderResponseItemDto.Payer);
        OrderItems = new OrderItemsResponse(paymentOrderResponseItemDto.OrderItems);
        History = new HistoryResponse(paymentOrderResponseItemDto.History);
        Failed = new FailedResponse(paymentOrderResponseItemDto.Failed);
        Aborted = new AbortedResponse(paymentOrderResponseItemDto.Aborted);
        Paid = new PaidResponse(paymentOrderResponseItemDto.Paid);
        Cancelled = new CancelledResponse(paymentOrderResponseItemDto.Cancelled);
        FinancialTransactions = new FinancialTransactionsResponse(paymentOrderResponseItemDto.FinancialTransactions);
        FailedAttempts = new FailedAttemptsResponse(paymentOrderResponseItemDto.FailedAttempts);
        Metadata = new MetadataResponse(paymentOrderResponseItemDto.Metadata);
    }

    public string Id { get; }
    public DateTime Created { get; }
    public DateTime Updated { get; }
    public string Operation { get; }
    public string Status { get; }
    public string Currency { get; }
    public Amount VatAmount { get; }
    public Amount Amount { get; }
    public string Description { get; }
    public string InitiatingSystemUserAgent { get; }
    public Language Language { get; }
    public string[] AvailableInstruments { get; }
    public string Implementation { get; }
    public bool InstrumentMode { get; }
    public bool GuestMode { get; }
    public PayerResponse Payer { get; }
    public OrderItemsResponse OrderItems { get; }
    public HistoryResponse History { get; }
    public FailedResponse Failed { get; }
    public AbortedResponse Aborted { get; }
    public PaidResponse Paid { get; }
    public CancelledResponse Cancelled { get; }
    public FinancialTransactionsResponse FinancialTransactions { get; }
    public FailedAttemptsResponse FailedAttempts { get; }
    public MetadataResponse Metadata { get; }
}

public class PayerResponse : Identifiable
{
    internal PayerResponse(PayerResponseDto payer) : base(payer.id)
    {
    }
}

public class OrderItemsResponse : Identifiable
{
    internal OrderItemsResponse(OrderItemResponseDto orderItems) : base(orderItems.id)
    {
    }
}

public class HistoryResponse : Identifiable
{
    internal HistoryResponse(HistoryResponseDto historyResponse) : base(historyResponse.id)
    {
    }
}

public class FailedResponse : Identifiable
{
    internal FailedResponse(FailedResponseDto failedResponse) : base(failedResponse.id)
    {
    }
}

public class AbortedResponse : Identifiable
{
    internal AbortedResponse(AbortedResponseDto abortedResponse) : base(abortedResponse.id)
    {
    }
}

public class PaidResponse : Identifiable
{
    internal PaidResponse(PaidResponseDto paidResponse) : base(paidResponse.id)
    {
    }
}

public class CancelledResponse : Identifiable
{
    internal CancelledResponse(CancelledResponseDto cancelledResponse) : base(cancelledResponse.id)
    {
    }
}

public class FinancialTransactionsResponse : Identifiable
{
    internal FinancialTransactionsResponse(FinancialTransactionsResponseDto financialTransactionsResponse) : base(financialTransactionsResponse.id)
    {
    }
}

public class FailedAttemptsResponse : Identifiable
{
    internal FailedAttemptsResponse(FailedAttemptsResponseDto failedAttemptsResponse) : base(failedAttemptsResponse.id)
    {
    }
}

public class MetadataResponse : Identifiable
{
    internal MetadataResponse(MetadataResponseDto metadataResponse) : base(metadataResponse.id)
    {
    }
}

public class Operations
{
    internal Operations(OperationsResponseDto operationsResponse)
    {
        Method = operationsResponse.Method;
        Href = operationsResponse.Href;
        Rel = operationsResponse.Rel;
        ContentType = operationsResponse.ContentType;
    }

    public string Method { get; set; }
    public string Href { get; set; }
    public string Rel { get; set; }
    public string ContentType { get; set; }
}
