namespace Finat.Core.Responses;

public class PagedResponse<T> : Response<T>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    public int TotalItems { get; set; }
    public PagedResponse(int code, T data, int page, int pageSize, int totalItems, List<string>? errors = null)
        : base(code, data, errors)
    {
        if (page < 1)  page = Configuration.DefaultPage;
        if (pageSize < 1) pageSize = Configuration.DefaultPageSize;
        if (pageSize > Configuration.MaxPageSize) pageSize = Configuration.MaxPageSize;

        Data = data;
        CurrentPage = page;
        PageSize = pageSize;
        TotalItems = totalItems;
    }
}
