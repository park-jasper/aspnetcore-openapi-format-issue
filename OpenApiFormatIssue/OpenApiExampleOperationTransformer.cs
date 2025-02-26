using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace OpenApiFormatIssue;

public class OpenApiExampleOperationTransformer : IOpenApiOperationTransformer
{
    public Task TransformAsync(OpenApiOperation operation, OpenApiOperationTransformerContext context,
        CancellationToken cancellationToken)
    {
        var ok = operation.Responses["200"];
        ok.Content["application/json"].Examples.Add(
            "FormatIssue",
            new OpenApiExample()
            {
                Value = new OpenApiDouble(1.234),
            });

        return Task.CompletedTask;
    }
}