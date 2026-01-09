using Finat.Api.Endpoints;

namespace Finat.Api.Extensions;

public static class EnpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        CategoriesEndpoint.Map(app);
    }
}
