using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Gunnsoft.Api.Authentication
{
    public class ClaimsClientIdAccessor : IClientIdAccessor
    {
        private readonly Lazy<string> _clientId;

        public ClaimsClientIdAccessor
        (
            IHttpContextAccessor httpContextAccessor
        )
        {
            _clientId = new Lazy<string>
            (
                () => httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == JwtClaimTypes.ClientId)?.Value
            );
        }

        public string ClientId => _clientId.Value;
    }
}
