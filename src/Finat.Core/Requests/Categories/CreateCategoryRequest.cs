namespace Finat.Core.Requests.Categories;

public class CreateCategoryRequest : Request
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
