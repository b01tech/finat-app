namespace Finat.Api.Extensions;

public static class DocumentationApiExtension
{
    public static IServiceCollection AddDocumentationApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
    public static void UseSwaggerDocs(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
