using System.Net;
using System.Threading.Tasks;
using Gunnsoft.Api.Exceptions.UnknownSubject.Version1;
using Gunnsoft.Api.Models.UnknownSubject.Version1;
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