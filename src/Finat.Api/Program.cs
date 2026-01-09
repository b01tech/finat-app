using Finat.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDocumentationApi();

var app = builder.Build();
app.UseSwaggerDocs();
app.UseHttpsRedirection();

app.Run();
