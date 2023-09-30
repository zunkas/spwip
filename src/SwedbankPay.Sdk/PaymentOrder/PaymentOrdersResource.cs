using SwedbankPay.Sdk.Extensions;

namespace SwedbankPay.Sdk.PaymentOrder;

public class PaymentOrdersResource : ResourceBase, IPaymentOrdersResource
{
    public PaymentOrdersResource(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    ///     Create a payment order
    /// </summary>
    /// <param name="paymentOrderRequest"></param>
    /// <param name="paymentOrderExpand"></param>
    /// <returns></returns>
    public async Task<PaymentOrderResponse> Create(PaymentOrderRequest paymentOrderRequest,
        PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
    {
        var url = new Uri("/psp/paymentorders", UriKind.Relative).GetUrlWithQueryString(paymentOrderExpand);

        var request = new PaymentOrderRequestDto(paymentOrderRequest);

        var paymentOrderResponseDto = await HttpClient.PostAsJsonAsync<PaymentOrderResponseDto>(url, request);

        return new PaymentOrderResponse(paymentOrderResponseDto, HttpClient);
    }
}

public interface IPaymentOrdersResource
{
    /// <summary>
    ///     Creates a payment order
    /// </summary>
    /// <param name="paymentOrderRequest"></param>
    /// <param name="paymentOrderExpand"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    /// <returns></returns>
    Task<PaymentOrderResponse> Create(PaymentOrderRequest paymentOrderRequest,
        PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);


    /// <summary>
    ///     Get payment order for the given id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="paymentOrderExpand"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    /// <returns></returns>
    // Task<IPaymentOrderResponse> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);
}