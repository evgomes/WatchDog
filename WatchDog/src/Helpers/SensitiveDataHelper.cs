using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;
using WatchDog.src.Attributes;

namespace WatchDog.src.Helpers
{
    internal static class SensitiveDataHelper
    {
        public static string ReplaceRequestBodySensitiveContent(HttpContext context, string? requestBody)
        {
            if (string.IsNullOrWhiteSpace(requestBody))
            {
                return requestBody;
            }

            // Finds the controller action description of the current endpoint.
            var endpoint = context.GetEndpoint();
            var actionDescriptor = endpoint.Metadata.GetMetadata<ActionDescriptor>() as ControllerActionDescriptor;
            if (actionDescriptor == null)
            {
                return requestBody;
            }


            // Finds the parameter that contains request body data.
            var body = actionDescriptor.Parameters.FirstOrDefault(x => x.BindingInfo.BindingSource.Id.Equals("Body", StringComparison.OrdinalIgnoreCase));
            if (body == null)
            {
                return requestBody;
            }

            // Uses reflection to see if any model property contains the sensitive data attribute defined.
            var bodyModelProperties = body.ParameterType.GetProperties();
            var sensitiveProperties = bodyModelProperties.Where(property => property.GetCustomAttribute<SensitiveStringAttribute>() != null).Select(property => property.Name.ToLowerInvariant());
            if (!sensitiveProperties.Any())
            {
                return requestBody;
            }

            // If there are sensitive data properties, then we use a JObject instance
            // to replace their content with censored strings with the same length as its content.
            var modifiedBody = JObject.Parse(requestBody);
            string value;

            foreach (var property in sensitiveProperties)
            {
                var token = modifiedBody[property];
                if (token != null && token.Type == JTokenType.String)
                {
                    value = token.ToString();
                    modifiedBody[property] = string.IsNullOrWhiteSpace(value)
                        ? value
                        : new string('*', value.Length);
                }
            }

            return modifiedBody.ToString(Newtonsoft.Json.Formatting.None);
        }
    }
}