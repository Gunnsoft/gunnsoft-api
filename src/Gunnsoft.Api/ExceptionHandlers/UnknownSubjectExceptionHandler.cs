using System.Net;
using System.Threading.Tasks;
using Gunnsoft.Api.Exceptions.UnknownSubject;
using Gunnsoft.Api.Models.UnknownSubject;
using Microsoft.AspNetCore.Http;

namespace Gunnsoft.Api.ExceptionHandlers
{
    public class UnknownSubjectExceptionHandler
        : IExceptionHandler<UnknownSubjectException>
    {
        public async Task HandleAsync
        (
            HttpContext context,
            UnknownSubjectException exception
        )
        {
            var response = new UnknownSubjectResponse();

            await context.Response.WriteJsonAsync
            (
                HttpStatusCode.Unauthorized,
                response,
                JsonConstants.JsonSerializerSettings
            );
        }
    }
}