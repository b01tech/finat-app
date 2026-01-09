using Finat.Core.Models;
using Finat.Core.Requests.Categories;
using Finat.Core.Responses;

namespace Finat.Core.Handlers;

public interface ICategoryHandler
{
    Task<Response<Category>> CreateCategoryAsync(CreateCategoryRequest request);
    Task<Response<Category>> UpdateCategoryAsync(UpdateCategoryRequest request);
    Task<Response<Category>> DeleteCategoryAsync(DeleteCategoryRequest request);
    Task<Response<Category>> GetCategoryByIdAsync(GetByIdCategoryRequest request);
    Task<Response<List<Category>>> GetAllCategoriesAsync(GetAllCategoryRequest request);
}
