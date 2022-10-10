namespace AD.Commons;

public class PagedResult<TData> : Result
{
    public PagedResult() { }

    public PagedResult(IEnumerable<TData> data, int page, int count, int total)
    {
        Page = page;
        Count = count;
        Total = total;
        Data = data;
    }

    public PagedResult(string message)
    {
        Message = message;
    }

    public int Page { get; }
    public int Count { get; }
    public int Total { get; }

    public IEnumerable<TData> Data { get; set; }

    public static PagedResult<TData> Ok(IEnumerable<TData> data, int page, int count, int total) =>
        new PagedResult<TData>(data, page, count, total) { Success = true, StatusCode = 200 };

    public static PagedResult<TData> Created(IEnumerable<TData> data, int page, int count, int total) =>
        new PagedResult<TData>(data, page, count, total) { Success = true, StatusCode = 201 };

    public static PagedResult<TData> Updated(IEnumerable<TData> data, int page, int count, int total) =>
        new PagedResult<TData>(data, page, count, total);

    public static PagedResult<TData> Failure(string message) =>
        new PagedResult<TData>(message) { StatusCode = 500, Success = false };

    public static PagedResult<TData> Bad(string message) =>
        new PagedResult<TData>(message) { StatusCode = 400, Success = false };

    public static PagedResult<TData> NotFound<TData>(string message) =>
        new PagedResult<TData>(message) { StatusCode = 404, Success = false };
}