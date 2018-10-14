using System.Collections.Generic;
using Gunnsoft.Api.Models.Error;

namespace Gunnsoft.Api.Models.ValidationFailed
{
    public class ValidationFailedResponse : ErrorResponse
    {
        public ValidationFailedResponse
        (
            IReadOnlyCollection<ValidationError> validationErrors
        )
            : base
            (
                "ValidationFailed",
                "The request contains one or more validation errors."
            )
        {
            ValidationErrors = validationErrors;
        }

        public IReadOnlyCollection<ValidationError> ValidationErrors { get; }
    }
}