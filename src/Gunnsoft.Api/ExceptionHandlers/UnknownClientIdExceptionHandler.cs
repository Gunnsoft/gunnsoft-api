using System.Net;
using System.Threading.Tasks;
using Gunnsoft.Api.Exceptions.UnknownClientId;
using Gunnsoft.Api.Models.UnknownClientId;
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