using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gunnsoft.Api.Authentication;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace Gunnsoft.Api.Middleware.ClientIdEnricher
{
    public class ClientIdEnricherMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IReadOnlyCollection<IClientIdAccessor> _clientIdAccessors;

        public ClientIdEnricherMiddleware
        (
            RequestDelegate next,
            IReadOnlyCollection<IClientIdAccessor> clientIdAccessors
        )
        {
            _next = next;
            _clientIdAccessors = clientIdAccessors;
        }

        public async Task Invoke
        (
            HttpContext context
        )
        {
            using (LogContext.PushProperty("ClientId", _clientIdAccessors.FirstOrDefault(sa => sa != null)?.ClientId))
            {
                await _next(context);
            }
        }
    }
}
