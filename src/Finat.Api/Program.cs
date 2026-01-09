using Finat.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDocumentationApi()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseSwaggerDocs();
app.UseHttpsRedirection();

app.Run();
