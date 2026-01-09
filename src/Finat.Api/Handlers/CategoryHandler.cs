using Finat.Api.Infra.Data;
using Finat.Core.Handlers;
using Finat.Core.Models;
using Finat.Core.Requests.Categories;
using Finat.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Finat.Api.Handlers;

internal class CategoryHandler(AppDbContext dbContext) : ICategoryHandler
{
    public async Task<Response<Category>> CreateCategoryAsync(CreateCategoryRequest request)
    {
        var category = new Category
        {
            Title = request.Title,
            Description = request.Description,
            UserId = request.UserId,
        };
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync();
        return new Response<Category>(StatusCodes.Status201Created, category);
    }

    public async Task<Response<Category>> UpdateCategoryAsync(UpdateCategoryRequest request)
    {
        var category = await dbContext.Categories.FindAsync(request.Id);
        if (category is null)
            return new Response<Category>(StatusCodes.Status404NotFound, errors: ["Category not found"]);
        category.Title = request.Title ?? category.Title;
        category.Description = request.Description ?? category.Description;
        await dbContext.SaveChangesAsync();
        return new Response<Category>(StatusCodes.Status200OK, category);
    }

    public async Task<Response<Category>> DeleteCategoryAsync(DeleteCategoryRequest request)
    {
        var category = await dbContext.Categories.FindAsync(request.Id);
        if (category is null)
            return new Response<Category>(StatusCodes.Status404NotFound, errors: ["Category not found"]);
        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync();
        return new Response<Category>(StatusCodes.Status200OK, category);
    }

    public async Task<Response<Category>> GetCategoryByIdAsync(GetByIdCategoryRequest request)
    {
        var result = await dbContext.Categories.FindAsync(request.Id);
        if (result is null)
            return new Response<Category>(StatusCodes.Status404NotFound, errors: ["Category not found"]);
        return new Response<Category>(StatusCodes.Status200OK, result);
    }

    public async Task<PagedResponse<List<Category>>> GetAllCategoriesAsync(
        GetAllCategoryRequest request)
    {
        var query = dbContext.Categories.AsNoTracking();
        var count = await query.CountAsync();

        var result = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PagedResponse<List<Category>>(
            StatusCodes.Status200OK,
            result,
            request.PageNumber,
            request.PageSize,
            count);
    }
}
