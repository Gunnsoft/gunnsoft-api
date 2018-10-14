using System.Net;
using System.Threading.Tasks;
using Gunnsoft.Api.Exceptions.AuthenticatedUserNotFound;
using Gunnsoft.Api.Models.AuthenticatedUserNotFound;
using Microsoft.AspNetCore.Http;

namespace Gunnsoft.Api.ExceptionHandlers.AuthenticatedUserNotFound
{
    public class AuthenticatedUserNotFoundExceptionHandler
        : IExceptionHandler<AuthenticatedUserNotFoundException>
    {
        public async Task HandleAsync
        (
            HttpContext context,
            AuthenticatedUserNotFoundException exception
        )
        {
            var response = new AuthenticatedUserNotFoundResponse();

            await context.Response.WriteJsonAsync
            (
                HttpStatusCode.Forbidden,
                response,
                JsonConstants.JsonSerializerSettings
            );
        }
    }
}