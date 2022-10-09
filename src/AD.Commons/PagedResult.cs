namespace AD.Commons;

public class PagedResult<TData>:Result
{
    public PagedResult() { }

    public PagedResult(IEnumerable<TData> data,int page,int count, int total)
    {
        Page = page;
        Count = count;
        Total = total;
    }

    public PagedResult(string message)
    {
        Message = message;
    }

    public int Page { get; }
    public int Count { get; }
    public int Total { get; }
    
    public IEnumerable<TData> Data { get; set; }

    public static PagedResult<T> Ok<T>(IEnumerable<T> data, int page, int count, int total) =>
        new PagedResult<T>(data, page, count, total) { Success = true, StatusCode = 201};
    
    public static PagedResult<T> Created<T>(IEnumerable<T> data, int page, int count, int total) =>
        new PagedResult<T>(data, page, count, total) { Success = true, StatusCode = 201};

    public static PagedResult<T> Updated<T>(IEnumerable<T> data, int page, int count, int total) =>
        new PagedResult<T>(data, page, count, total);
    
    public static PagedResult<T> Failure<T>(string message) =>
        new PagedResult<T>(message) { StatusCode = 500, Success = false};
    
    public static PagedResult<T> Bad<T>(string message) =>
        new PagedResult<T>(message) { StatusCode = 400, Success = false};
    
    public static PagedResult<T> NotFound<T>(string message) =>
        new PagedResult<T>(message) { StatusCode = 404, Success = false};
}