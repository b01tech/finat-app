namespace Finat.Core.Responses;

public class Response<T>
{
    private readonly int _code;

    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    public bool IsSuccess => _code is >= 200 and <= 299;

    protected Response() { }

    public Response(int code, T? data = default, List<string>? errors = null)
    {
        _code = code;
        Data = data;
        Errors = errors;
    }
}
