using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.Helpers
{
    public class PreventTokenEncodingOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters != null)
            {
                foreach (var parameter in operation.Parameters)
                {
                    if (parameter.Name == "Token") // Or your token parameter name
                    {
                        parameter.AllowReserved = true; // This prevents encoding
                    }
                }
            }
        }
    }

}
