using System.Net;
using System.Threading.Tasks;
using Gunnsoft.Api.Exceptions.UnknownClientId.Version1;
using Gunnsoft.Api.Models.UnknownClientId.Version1;
using Microsoft.AspNetCore.Http;

namespace Gunnsoft.Api.ExceptionHandlers
{
    public class UnknownClientIdExceptionHandler
        : IExceptionHandler<UnknownClientIdException>
    {
        public async Task HandleAsync
        (
            HttpContext context,
            UnknownClientIdException exception
        )
        {
            var response = new UnknownClientIdResponse();

            await context.Response.WriteJsonAsync
            (
                HttpStatusCode.Unauthorized,
                response,
                JsonConstants.JsonSerializerSettings
            );
        }
    }
}