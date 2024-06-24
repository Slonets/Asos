using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;



namespace Core.Helpers
{
    public class EnumSchemaFilter:ISchemaFilter
    {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum.Clear();

                var enumValues = Enum.GetValues(context.Type);
                foreach (var enumValue in enumValues)
                {
                    var enumMemberAttribute = context.Type.GetMember(enumValue.ToString())
                        .FirstOrDefault()
                        ?.GetCustomAttribute<EnumMemberAttribute>();

                    var enumName = enumMemberAttribute?.Value ?? enumValue.ToString();
                    schema.Enum.Add(new OpenApiString(enumName));
                }
            }
        }
    }
}
