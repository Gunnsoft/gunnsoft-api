using System.Linq;
using Gunnsoft.Api.Models.ValidationFailed.Version1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Gunnsoft.Api.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var validationErrors = context.ModelState
                .SelectMany(kvp => kvp.Value.Errors.Select(e => new ValidationError(kvp.Key, e.ErrorMessage)))
                .Where(ve => !string.IsNullOrWhiteSpace(ve.ErrorMessage))
                .OrderBy(ve => ve.PropertyName)
                .ThenBy(ve => ve.ErrorMessage)
                .ToList();

            if (validationErrors.Any())
            {
                var logger =
                    (ILogger<ValidateModelStateAttribute>)context.HttpContext.RequestServices.GetService(
                        typeof(ILogger<ValidateModelStateAttribute>));

                logger.LogInformation
                (
                    "ModelState is invalid. {@ValidationErrors}",
                    validationErrors
                );
            }

            var response = validationErrors.Any() ? new ValidationFailedResponse(validationErrors) : null;

            context.Result = new BadRequestObjectResult(response);
        }
    }
}