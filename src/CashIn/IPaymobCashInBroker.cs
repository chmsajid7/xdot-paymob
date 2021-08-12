// Copyright (c) Mahmoud Shaheen, 2021. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.

using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading.Tasks;
using X.Paymob.CashIn.Models.Orders;
using X.Paymob.CashIn.Models.Payment;
using X.Paymob.CashIn.Models.Transactions;

namespace X.Paymob.CashIn {
    public interface IPaymobCashInBroker {
        [Pure] string CreateIframeSrc(string token);

        /// <summary>Create order. Order is a logical container for a transaction(s).</summary>
        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInCreateOrderResponse> CreateOrderAsync(CashInCreateOrderRequest request);

        /// <summary>
        /// Get payment key which is used to authenticate payment request and verifying transaction
        /// request metadata.
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInPaymentKeyResponse> RequestPaymentKeyAsync(CashInPaymentKeyRequest request);

        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInWalletPayResponse> CreateWalletPayAsync(string paymentKey, string phoneNumber);

        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInKioskPayResponse> CreateKioskPayAsync(string paymentKey);

        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInCashCollectionPayResponse> CreateCashCollectionPayAsync(string paymentKey);

        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInSavedTokenPayResponse> CreateSavedTokenPayAsync(string paymentKey, string savedToken);

        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInTransactionsPage?> GetTransactionsPageAsync(CashInTransactionsPageRequest request);

        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInTransaction?> GetTransactionAsync(string transactionId);

        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInOrder?> GetOrderAsync(string orderId);

        /// <exception cref="HttpRequestException"></exception>
        [Pure] Task<CashInOrdersPage?> GetOrdersPageAsync(CashInOrdersPageRequest request);

        /// <summary>Validate the identity and integrity for "Paymob Accept"'s callback submission.</summary>
        /// <param name="concatenatedString">Object concatenated string.</param>
        /// <param name="hmac">Received HMAC.</param>
        /// <returns>True if is valid, otherwise return false.</returns>
        [Pure] bool Validate(string concatenatedString, string hmac);
    }
}