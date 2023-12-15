namespace SwedbankPay.Sdk.PaymentOrder.History;

internal record HistoryResponseDto : IdentifiableDto
{
    public IList<HistoryListItemDto>? HistoryList { get; init; }

    public HistoryResponseDto(string id) : base(id)
    {
    }

    public HistoryResponse Map()
    {
        return new HistoryResponse(this);
    }
}