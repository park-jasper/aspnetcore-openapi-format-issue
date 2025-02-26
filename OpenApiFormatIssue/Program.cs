using System.Globalization;
using OpenApiFormatIssue;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(
    options => options.AddOperationTransformer<OpenApiExampleOperationTransformer>());

var app = builder.Build();

app
    .MapGet("/", () => Results.Ok(new ApiResponse(4.5)))
    .WithName("ExampleEndpoint")
    .Produces<ApiResponse>();
app.MapOpenApi();

// simulate running this code on a machine with e.g. german culture
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");

app.Run();
