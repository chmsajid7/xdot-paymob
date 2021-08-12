// Copyright (c) Mahmoud Shaheen, 2021. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.

using AutoFixture;
using NSubstitute;
using X.Paymob.CashIn;
using Xunit;

namespace CashIn.Tests.Unit {
    public partial class PaymobCashInBrokerTests : IClassFixture<PaymobCashInFixture> {
        private readonly PaymobCashInFixture _fixture;

        public PaymobCashInBrokerTests(PaymobCashInFixture fixture) => _fixture = fixture;

        private string GetRandomString => _fixture.AutoFixture.Create<string>();

        private (IPaymobCashInAuthenticator authenticator, string token) _SetupGentAuthenticationToken() {
            var token = _fixture.AutoFixture.Create<string>();
            var authenticator = Substitute.For<IPaymobCashInAuthenticator>();
            authenticator.GetAuthenticationTokenAsync().Returns(token);
            return (authenticator, token);
        }
    }
}