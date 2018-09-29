using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Http;

namespace Gunnsoft.Api.Middleware.ClientIdHeader
{
    public class ClientIdHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public ClientIdHeaderMiddleware
        (
            RequestDelegate next
        )
        {
            _next = next;
        }

        public async Task Invoke
        (
            HttpContext context
        )
        {
            context.Request.Headers.TryGetValue("X-ClientId", out var headerClientId);
            var clientId = headerClientId.FirstOrDefault();

            if (string.IsNullOrEmpty(clientId))
            {
                await _next(context);

                return;
            }

            var claims = context.User.Claims.ToList();
            claims.Add(new Claim(JwtClaimTypes.ClientId, clientId));
            var claimsIdentity = new ClaimsIdentity(claims, "Header");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            context.User = claimsPrincipal;

            await _next(context);
        }
    }
}