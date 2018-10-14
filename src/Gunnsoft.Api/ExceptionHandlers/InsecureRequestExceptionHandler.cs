using System.Net;
using System.Threading.Tasks;
using Gunnsoft.Api.Middleware.SecureRequests;
using Gunnsoft.Api.Models.InsecureRequest;
using Microsoft.AspNetCore.Http;

namespace Gunnsoft.Api.ExceptionHandlers
{
    public class InsecureRequestExceptionHandler
        : IExceptionHandler<InsecureRequestException>
    {
        public async Task HandleAsync
        (
            HttpContext context,
            InsecureRequestException exception
        )
        {
            var response = new InsecureRequestResponse();

            await context.Response.WriteJsonAsync
            (
                HttpStatusCode.HttpVersionNotSupported,
                response,
                JsonConstants.JsonSerializerSettings
            );
        }
    }
}