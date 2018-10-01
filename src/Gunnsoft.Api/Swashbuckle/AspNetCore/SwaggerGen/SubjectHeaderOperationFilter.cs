using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;

namespace Swashbuckle.AspNetCore.SwaggerGen
{
    public class SubjectHeaderOperationFilter : IOperationFilter
    {
        public void Apply
        (
            Operation operation,
            OperationFilterContext context
        )
        {
            if (context.ApiDescription.ControllerAttributes().OfType<AllowAnonymousAttribute>().Any()
                || context.ApiDescription.ActionAttributes().OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "X-Subject",
                In = "header",
                Type = "string",
                Required = false
            });

            if (!operation.Responses.ContainsKey("401"))
            {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });
            }

            if (!operation.Responses.ContainsKey("403"))
            {
                operation.Responses.Add("403", new Response { Description = "Forbidden" });
            }
        }
    }
    }