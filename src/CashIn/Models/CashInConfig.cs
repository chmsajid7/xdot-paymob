// Copyright (c) Mahmoud Shaheen, 2021. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.

using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace X.Paymob.CashIn.Models {
    [PublicAPI]
    public class CashInConfig {
        /// <summary>API base url default: "https://accept.paymobsolutions.com/api"</summary>
        [Required]
        public string ApiBaseUrl { get; init; } = "https://accept.paymobsolutions.com/api";

        /// <summary>Iframe base url default: "https://accept.paymob.com/api/acceptance/iframes"</summary>
        [Required]
        public string IframeBaseUrl { get; init; } = "https://accept.paymob.com/api/acceptance/iframes";

        /// <summary>Iframe Id.</summary>
        [Required]
        public string IframeId { get; init; } = default!;

        /// <summary>
        /// The unique identifier for the merchant which used to authenticate requests calling
        /// any of the "Paymob Accept"'s API.
        /// </summary>
        [Required]
        public string ApiKey { get; init; } = default!;

        /// <summary>Used to check the integrity of the callback inputs.</summary>
        [Required]
        public string Hmac { get; init; } = default!;

        /// <summary>The default expiration time of this payment token in milliseconds.</summary>
        [Range(2 * 60 * 1000, int.MaxValue, ErrorMessage = "The {0} must be greater than {1}.")]
        public int ExpirationPeriod { get; init; } = 3600;
    }
}
