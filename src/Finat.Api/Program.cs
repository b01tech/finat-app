using Finat.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDocumentationApi()
    .AddInfrastructure(builder.Configuration)
    .AddHandlers();

var app = builder.Build();
app.UseSwaggerDocs();
app.MapEndpoints();
app.UseHttpsRedirection();

app.Run();
