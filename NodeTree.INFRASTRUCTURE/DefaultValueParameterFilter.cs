using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;

namespace NodeTree.INFRASTRUCTURE
{
    public class DefaultValueParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            var defaultValueAttribute = context.ParameterInfo.CustomAttributes
                .FirstOrDefault(attr => attr.AttributeType == typeof(DefaultValueAttribute));

            if (defaultValueAttribute != null)
            {
                parameter.Example = new OpenApiString(defaultValueAttribute.ConstructorArguments[0].Value.ToString());
            }
        }
    }

}
