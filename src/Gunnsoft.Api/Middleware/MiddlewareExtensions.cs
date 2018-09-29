using Gunnsoft.Api.Middleware.JsonExceptions;
using Gunnsoft.Api.Middleware.SecureRequests;
using Gunnsoft.Api.Middleware.SubjectHeader;
using Gunnsoft.Api.Middleware.SubjectEnricher;
using Microsoft.AspNetCore.Builder;

namespace Gunnsoft.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseJsonExceptions
        (
            this IApplicationBuilder extended
        )
        {
            extended.UseMiddleware<JsonExceptionsMiddleware>();

            return extended;
        }

        public static IApplicationBuilder UseSecureRequests
        (
            this IApplicationBuilder extended
        )
        {
            extended.UseMiddleware<SecureRequestsMiddleware>();

            return extended;
        }

        public static IApplicationBuilder UseSubjectEnricher
        (
            this IApplicationBuilder app
        )
        {
            app.UseMiddleware<SubjectEnricherMiddleware>();

            return app;
        }

        public static IApplicationBuilder UseSubHeader
        (
            this IApplicationBuilder extended
        )
        {
            extended.UseMiddleware<SubjectHeaderMiddleware>();

            return extended;
        }
    }
}