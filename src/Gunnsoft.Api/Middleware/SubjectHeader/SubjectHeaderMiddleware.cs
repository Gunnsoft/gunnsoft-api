using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Http;

namespace Gunnsoft.Api.Middleware.SubjectHeader
{
    public class SubjectHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public SubjectHeaderMiddleware
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
            context.Request.Headers.TryGetValue("X-Subject", out var headerSub);
            var subject = headerSub.FirstOrDefault();

            if (string.IsNullOrEmpty(subject))
            {
                await _next(context);

                return;
            }

            var claims = context.User.Claims.ToList();
            claims.Add(new Claim(JwtClaimTypes.Subject, subject));
            var claimsIdentity = new ClaimsIdentity(claims, "Header");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            context.User = claimsPrincipal;

            await _next(context);
        }
    }
}