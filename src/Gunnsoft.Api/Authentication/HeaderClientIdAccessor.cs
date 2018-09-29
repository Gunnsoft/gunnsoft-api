using Microsoft.AspNetCore.Http;
using System;

namespace Gunnsoft.Api.Authentication
{
    public class HeaderClientIdAccessor : IClientIdAccessor
    {
        private readonly Lazy<string> _clientId;

        public HeaderClientIdAccessor
        (
            IHttpContextAccessor httpContextAccessor
        )
        {
            _clientId = new Lazy<string>
            (
                () => httpContextAccessor.HttpContext.Request.Headers["X-ClientId"]
            );
        }

        public string ClientId => _clientId.Value;
    }
}
