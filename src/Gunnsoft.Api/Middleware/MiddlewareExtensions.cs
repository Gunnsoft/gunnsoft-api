using Gunnsoft.Api.Middleware.ClientIdHeader;
using Gunnsoft.Api.Middleware.ClientIdEnricher;
using Gunnsoft.Api.Middleware.JsonExceptions;
using Gunnsoft.Api.Middleware.SecureRequests;
using Gunnsoft.Api.Middleware.SubjectHeader;
using Gunnsoft.Api.Middleware.SubjectEnricher;
using Microsoft.AspNetCore.Builder;

namespace Gunnsoft.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseClientIdEnricher
        (
            this IApplicationBuilder app
        )
        {
            app.UseMiddleware<ClientIdEnricherMiddleware>();

            return app;
        }

        public static IApplicationBuilder UseClientIdHeader
        (
            this IApplicationBuilder extended
        )
        {
            extended.UseMiddleware<ClientIdHeaderMiddleware>();

            return extended;
        }

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

        public static IApplicationBuilder UseSubjectHeader
        (
            this IApplicationBuilder extended
        )
        {
            extended.UseMiddleware<SubjectHeaderMiddleware>();

            return extended;
        }
    }
}