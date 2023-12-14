namespace SwedbankPay.Sdk.PaymentOrder.Models;

public record FailedAttemptsResponse : Identifiable
{
    public IList<FailedAttemptListItem>? FailedAttemptList { get; set; }

    internal FailedAttemptsResponse(FailedAttemptsResponseDto dto) : base(dto.Id)
    {
        FailedAttemptList = dto.FailedAttemptList?.Select(x => x.Map()).ToList();
    }
}