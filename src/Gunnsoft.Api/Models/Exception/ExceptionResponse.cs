using Gunnsoft.Api.Models.Error;

namespace Gunnsoft.Api.Models.Exception
{
    public class ExceptionResponse : ErrorResponse
    {
        public ExceptionResponse
        (
            Exception exception
        )
        {
            Exception = exception;
        }

        public ExceptionResponse
        (
            string errorCode,
            string errorMessage,
            Exception exception
        )
            : base
            (
                errorCode,
                errorMessage
            )
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}