using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.Tests.TestBuilders;

namespace SwedbankPay.Sdk.Tests;

public class PaymentOrderTests : ResourceTestsBase
{
    private readonly PaymentOrderRequestBuilder paymentOrderRequestBuilder = new PaymentOrderRequestBuilder();
    
    [Fact]
    public async Task CreatePaymentOrder_ShouldReturnPaymentOrder()
    {
        //ARRANGE

        var paymentOrderRequest = paymentOrderRequestBuilder.WithTestValues(PayeeId).WithOrderItems().Build();

        //ACT
        PaymentOrderResponse paymentOrder = await Sut.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
        Assert.NotNull(paymentOrder);
        Assert.NotEmpty(paymentOrder.Operations);
        // Assert.NotNull(paymentOrder.Operations.Abort);
    }
}