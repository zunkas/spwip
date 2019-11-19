﻿namespace SwedbankPay.Sdk.PaymentOrders
{
    using RestSharp;

    using SwedbankPay.Sdk.Exceptions;
    using SwedbankPay.Sdk.Payments;
    using SwedbankPay.Sdk.Transactions;

    using System;
    using System.Linq;
    using System.Threading.Tasks;


    public class PaymentOrdersResource : ResourceBase, IPaymentOrdersResource
    {
        public PaymentOrdersResource(SwedbankPayOptions swedbankPayOptions, ILogSwedbankPayHttpResponse logger = null) : base(swedbankPayOptions, logger)
        {
        }

        /// <summary>
        /// Creates a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotPlacePaymentOrderException"></exception>
        /// <returns></returns>
        public async Task<PaymentOrderResponseContainer> CreatePaymentOrder(PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            var url = $"/psp/paymentorders{GetExpandQueryString(paymentOrderExpand)}";

            var payload = new PaymentOrderRequestContainer(paymentOrderRequest);
            paymentOrderRequest.Operation = Operation.Purchase;

            Func<ProblemsContainer, Exception> onError = m => new CouldNotPlacePaymentOrderException(payload, m);
            var res = await CreateInternalClient().HttpRequest<PaymentOrderResponseContainer>(Method.POST, url, onError, payload);
            return res;
        }


        /// <summary>
        /// Gets an existing payment order.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotFindPaymentException"></exception>
        /// <returns></returns>
        public async Task<PaymentOrderResponseContainer> GetPaymentOrder(string id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new CouldNotFindPaymentException(id);
            }

            var url = $"{id}{GetExpandQueryString(paymentOrderExpand)}";

            Func<ProblemsContainer, Exception> onError = m => new CouldNotFindPaymentException(id, m);
            var res = await CreateInternalClient().HttpGet<PaymentOrderResponseContainer>(url, onError);
            return res;
        }

        /// <summary>
        /// Updates an existing payment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderRequest"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotUpdatePaymentOrderException"></exception>
        /// <returns></returns>
        public async Task<PaymentOrderResponseContainer> UpdatePaymentOrder(string id, PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "update-paymentorder-updateorder");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new OperationNotAvailableException(id, $"This payment cannot be updated. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }
            var url = $"{httpOperation.Href}{GetExpandQueryString(paymentOrderExpand)}";

            paymentOrderRequest.Operation = Operation.UpdateOrder;
            var payload = new PaymentOrderRequestContainer(paymentOrderRequest);

            Func<ProblemsContainer, Exception> onError = m => new CouldNotUpdatePaymentOrderException(payload, m);
            var res = await CreateInternalClient().HttpRequest<PaymentOrderResponseContainer>(httpOperation.Method, url, onError, payload);
            return res;
        }


        /// <summary>
        /// Aborts a payment
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <returns></returns>
        public async Task<PaymentOrderResponseContainer> AbortPaymentOrder(string id)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "update-paymentorder-abort");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new OperationNotAvailableException(id, $"This payment cannot be aborted. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            var paymentOrderRequest = new PaymentAbortRequestContainer();

            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(id, m);
            var res = await CreateInternalClient().HttpRequest<PaymentOrderResponseContainer>(httpOperation.Method, url, onError, paymentOrderRequest);
            return res;
        }

        /// <summary>
        /// Captures a payment
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="requestObject"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <returns></returns>
        public async Task<TransactionResponse> Capture(string id, TransactionRequest requestObject)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "create-paymentorder-capture");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new PaymentNotYetAuthorizedException(id, $"This payment cannot be captured. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;

            var payload = new TransactionRequestContainer(requestObject);

            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(url, m);
            var res = await CreateInternalClient().HttpRequest<CaptureTransactionResponseContainer>(httpOperation.Method, url, onError, payload);
            return res.Capture.Transaction;
        }


        /// <summary>
        /// Reverses a payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestObject"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <returns></returns>
        public async Task<TransactionResponse> Reversal(string id, TransactionRequest requestObject)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "create-paymentorder-reversal");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new PaymentNotYetAuthorizedException(id, $"This payment cannot be captured. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            var payload = new TransactionRequestContainer(requestObject);
            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(id, m);
            var res = await CreateInternalClient().HttpRequest<ReversalTransactionResponseContainer>(httpOperation.Method, url, onError, payload);
            return res.Reversal.Transaction;
        }

        /// <summary>
        /// Cancels a payment
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <param name="requestObject"></param>
        /// <returns></returns>
        public async Task<TransactionResponse> CancelPaymentOrder(string id, TransactionRequest requestObject)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "create-paymentorder-cancel");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new OperationNotAvailableException(id, $"This payment cannot be canceled. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            var payload = new TransactionRequestContainer(requestObject);
            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(id, m);
            var res = await CreateInternalClient().HttpRequest<CancellationTransactionResponseContainer>(httpOperation.Method, url, onError, payload);
            return res.Cancellation.Transaction;
        }
    }
}
