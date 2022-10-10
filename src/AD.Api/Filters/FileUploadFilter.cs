using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AD.Api.Filters;

public class FileUploadFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var formParameters = context.ApiDescription.ParameterDescriptions
            .Where(paramDesc => paramDesc.Source == BindingSource.Form || paramDesc.Source == BindingSource.FormFile ||
                                (paramDesc.ModelMetadata?.ElementType != null &&
                                 typeof(IFormFile).IsAssignableFrom(paramDesc.ModelMetadata?.ElementType)));

        if (formParameters.Any())
        {
            return;
        }

        if (operation.RequestBody != null)
        {
            return;
        }

        if (context.ApiDescription.HttpMethod != HttpMethod.Post.Method)
        {
            return;
        }

        operation.RequestBody = GetUploadMediaTypeForRequestBody();
    }

    private OpenApiRequestBody GetUploadMediaTypeForRequestBody()
    {
        var openApiSchema = new OpenApiSchema()
        {
            Type = "object", Properties = { ["file"] = new OpenApiSchema() { Type = "string", Format = "binary" } }
        };
        var uploadMediaType = new OpenApiMediaType() { Schema = openApiSchema };

        return new OpenApiRequestBody() { Content = { ["multipart/form-data"] = uploadMediaType } };
    }
}