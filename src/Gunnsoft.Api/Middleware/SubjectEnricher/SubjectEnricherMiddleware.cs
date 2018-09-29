using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gunnsoft.Api.Authentication;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace Gunnsoft.Api.Middleware.SubjectEnricher
{
    public class SubjectEnricherMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IReadOnlyCollection<ISubjectAccessor> _subAccessors;

        public SubjectEnricherMiddleware
        (
            RequestDelegate next,
            IReadOnlyCollection<ISubjectAccessor> subAccessors
        )
        {
            _next = next;
            _subAccessors = subAccessors;
        }

        public async Task Invoke
        (
            HttpContext context
        )
        {
            using (LogContext.PushProperty("Subject", _subAccessors.FirstOrDefault(sa => sa != null)?.Subject))
            {
                await _next(context);
            }
        }
    }
}
