using Finat.Api.Handlers;
using Finat.Core.Handlers;

namespace Finat.Api.Extensions;

public static class HandlersExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<ICategoryHandler, CategoryHandler>();
        return services;
    }
}
