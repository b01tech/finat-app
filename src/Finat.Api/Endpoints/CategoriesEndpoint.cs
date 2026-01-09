using Finat.Core.Handlers;
using Finat.Core.Models;
using Finat.Core.Requests.Categories;
using Finat.Core.Responses;

namespace Finat.Api.Endpoints;

public static class CategoriesEndpoint
{
    public static void Map(this WebApplication app)
    {
        var group = app.MapGroup("v1/categories").WithTags("Categories");

        group.MapGet("/", async (ICategoryHandler handler, [AsParameters] GetAllCategoryRequest request) =>
            {
                var result = await handler.GetAllCategoriesAsync(request);
                return Results.Ok(result);
            }).WithName("Categories: GetAll")
            .WithDescription("Returns all categories")
            .Produces<PagedResponse<List<Category>>>();

        group.MapPost("/", async (ICategoryHandler handler, CreateCategoryRequest request) =>
            {
                var result = await handler.CreateCategoryAsync(request);
                return Results.Created(string.Empty, result);
            }).WithName("Categories: Create")
            .WithDescription("Creates a new category")
            .Produces<Response<Category>>();

        group.MapGet("/{request}", async (ICategoryHandler handler, [AsParameters] GetByIdCategoryRequest request) =>
            {
                var result = await handler.GetCategoryByIdAsync(request);
                return Results.Ok(result);
            }).WithName("Categories: GetById")
            .WithDescription("Returns a category by id")
            .Produces<Response<Category>>();

        group.MapPut("/", async (ICategoryHandler handler, UpdateCategoryRequest request) =>
            {
                var result = await handler.UpdateCategoryAsync(request);
                return Results.Ok(result);
            }).WithName("Categories: Update")
            .WithDescription("Updates a category")
            .Produces<Response<Category>>();

        group.MapDelete("/{request}", async (ICategoryHandler handler, [AsParameters] DeleteCategoryRequest request) =>
            {
                var result = await handler.DeleteCategoryAsync(request);
                return Results.Ok(result);
            }).WithName("Categories: Delete")
            .WithDescription("Deletes a category")
            .Produces<Response<Category>>();
    }
}
