using SwedbankPay.Sdk.Extensions;

namespace SwedbankPay.Sdk.PaymentOrder;

public interface IPaymentOrderOperations
{
    /// <summary>
    /// Aborts the payment order, if available.
    /// </summary>
    Func<PaymentOrderAbortRequest, Task<IPaymentOrderResponse>>? Abort { get; }
    
    /// <summary>
    /// Returns details needed to created a hosted view for the payer to see the payment order, if available.
    /// </summary>
    HttpOperation View { get; }
}

internal class PaymentOrderOperations : OperationsBase, IPaymentOrderOperations
{
    public PaymentOrderOperations(IOperationList httpOperations, HttpClient httpClient)
    {
        foreach (var httpOperation in httpOperations)
        {
            switch (httpOperation.Rel.Value)
            {
                // case PaymentOrderResourceOperations.CreatePaymentOrderCapture:
                //     Capture = async payload =>
                //     {
                //         var requestDto = new PaymentOrderCaptureRequestDto(payload);
                //         var dto = await httpClient.SendAsJsonAsync<CaptureResponseDto>(httpOperation.Method,
                //             httpOperation.Href, requestDto);
                //         return new CaptureResponse(dto);
                //     };
                //     break;
                // case PaymentOrderResourceOperations.CreatePaymentOrderCancel:
                //     Cancel = async payload =>
                //     {
                //         var requestDto = new PaymentOrderCancelRequestDto(payload);
                //         var dto = await client.SendAsJsonAsync<CancelResponseDto>(httpOperation.Method,
                //             httpOperation.Href, requestDto);
                //         return new CancellationResponse(dto.Payment, dto.Cancellation.Map());
                //     };
                //     break;
                // case PaymentOrderResourceOperations.CreatePaymentOrderReversal:
                //     Reverse = async payload =>
                //     {
                //         var url = httpOperation.Href.GetUrlWithQueryString(PaymentExpand.All);
                //         var requestDto = new PaymentOrderReversalRequestDto(payload);
                //         var paymentOrderResponseContainer =
                //             await client.SendAsJsonAsync<ReversalResponseDto>(httpOperation.Method, url, requestDto);
                //         return new ReversalResponse(paymentOrderResponseContainer.Payment,
                //             paymentOrderResponseContainer.Reversal.Map());
                //     };
                //     break;
                // case PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder:
                //     Update = async payload =>
                //     {
                //         var url = httpOperation.Href.GetUrlWithQueryString(PaymentExpand.All);
                //         var requestDto = new PaymentOrderUpdateRequestDto(payload);
                //         var paymentOrderResponseContainer =
                //             await client.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url,
                //                 requestDto);
                //         return new PaymentOrderResponse(paymentOrderResponseContainer, client);
                //     };
                //     break;
                case PaymentOrderResourceOperations.Abort:
                    Abort = async payload =>
                    { 
                        var url = httpOperation.Href.GetUrlWithQueryString(PaymentOrderExpand.All);
                        var paymentOrderResponseContainer =
                            await httpClient.SendAsJsonAsync<PaymentOrderResponseDto>(httpOperation.Method, url, payload);
                        return new PaymentOrderResponse(paymentOrderResponseContainer, httpClient);
                    };
                    break;
                case PaymentOrderResourceOperations.ViewCheckout:
                    View = httpOperation;
                    break;
            }

            Add(httpOperation.Rel, httpOperation);
        }
    }
    
    public Func<PaymentOrderAbortRequest, Task<IPaymentOrderResponse>>? Abort { get; }
    public HttpOperation View { get; }
}