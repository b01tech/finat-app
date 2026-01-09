namespace Finat.Core.Requests;

public abstract class PagedRequest : Request
{
    public int PageNumber { get; set; } = Configuration.DefaultPage;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}
