﻿using Gunnsoft.Api.Models.Error.Version1;
using IdentityModel;

namespace Gunnsoft.Api.Models.UnknownClientId.Version1
{
    public class UnknownClientIdResponse : ErrorResponse
    {
        public UnknownClientIdResponse()
            : base
            (
                "UnknownClientId",
                $"The Client ID must be specified using the '{JwtClaimTypes.ClientId}' claim."
            )
        {
        }
    }
}