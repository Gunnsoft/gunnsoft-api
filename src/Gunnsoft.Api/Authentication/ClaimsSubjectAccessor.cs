using System;
using System.Linq;
using IdentityModel;
using Microsoft.AspNetCore.Http;

namespace Gunnsoft.Api.Authentication
{
    public class ClaimsSubjectAccessor : ISubjectAccessor
    {
        private readonly Lazy<string> _sub;

        public ClaimsSubjectAccessor
        (
            IHttpContextAccessor httpContextAccessor
        )
        {
            _sub = new Lazy<string>(() =>
                httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value);
        }

        public string Subject => _sub.Value;
    }
}