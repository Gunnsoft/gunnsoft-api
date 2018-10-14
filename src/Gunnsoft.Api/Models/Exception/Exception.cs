using System;

namespace Gunnsoft.Api.Models.Exception
{
    public class Exception
    {
        public Exception
        (
            System.Exception exception
        )
        {
            Message = exception.Message;
            StackTrace = exception.StackTrace;
            Type = exception.GetType();

            if (exception.InnerException != null)
            {
                InnerException = new Exception(exception.InnerException);
            }
        }

        public Exception InnerException { get; }
        public string Message { get; }
        public string StackTrace { get; }
        public Type Type { get; }
    }
}