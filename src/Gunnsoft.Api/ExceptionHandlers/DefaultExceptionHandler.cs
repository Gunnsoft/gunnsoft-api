using System.Net;
using System.Threading.Tasks;
using Gunnsoft.Api.Models.Error;
using Gunnsoft.Api.Models.Exception;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Exception = System.Exception;

namespace Gunnsoft.Api.ExceptionHandlers
{
    public class DefaultExceptionHandler : IDefaultExceptionHandler
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public DefaultExceptionHandler
        (
            IHostingEnvironment hostingEnvironment
        )
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task HandleAsync
        (
            HttpContext context,
            Exception exception
        )
        {
            ErrorResponse response;

            if (_hostingEnvironment.IsDevelopment())
            {
                response = new ExceptionResponse
                (
                    new Models.Exception.Exception(exception)
                );
            }
            else
            {
                response = new ErrorResponse();
            }

            await context.Response.WriteJsonAsync
            (
                HttpStatusCode.InternalServerError,
                response,
                JsonConstants.JsonSerializerSettings
            );
        }
    }
}