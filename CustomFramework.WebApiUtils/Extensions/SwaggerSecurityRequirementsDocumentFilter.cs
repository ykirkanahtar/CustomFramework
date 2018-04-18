using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CustomFramework.WebApiUtils.Extensions
{
    internal class SwaggerSecurityRequirementsDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument document, DocumentFilterContext context)
        {
            document.Security = new List<IDictionary<string, IEnumerable<string>>>
            {
                new Dictionary<string, IEnumerable<string>>()
                {
                    { "Bearer", new string[]{ } },
                    { "Basic", new string[]{ } },
                }
            };
        }
    }
}