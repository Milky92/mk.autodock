//TODO move to package mk.libs.commons!

using System.Net;

namespace AD.Commons;

/// <summary>
/// Default response descriptor.
/// </summary>
public class Result
{
    protected Result() { }

    private Result(int statusCode, bool success, string message)
    {
        Success = success;
        Message = message;
        StatusCode = statusCode;
    }

    public string Message { get; protected set; }

    public bool Success { get; protected set; }

    public int StatusCode { get; protected set; }

    private static Result New(int statusCode, bool success, string message) => new Result(statusCode, success, message);
    
    public static Result Ok() => New(200, true, string.Empty);
    public static Result Created() => New(201, true, string.Empty);
    public static Result Updated() => New(204, true, default);
    
    public static Result NotFound(string message) => New(404, false, message);
    public static Result Fail(string message) => New(500, false, message);
    public static Result Fail(int statusCode, string message) => New(statusCode, false, message);
}

/// <summary>
/// Parametrize response descriptor. Use static methods for describe http responses.
/// </summary>
/// <typeparam name="TData">Data bag</typeparam>
public class Result<TData> :Result
{
    public TData Data { get; private set; }
    
    public static Result<TData> Ok(TData data) => new Result<TData>().SetData(data)
        .SetSuccess(true)
        .SetStatusCode(200);

    public static new Result<TData> Created() =>
        new Result<TData>()
            .SetSuccess(true)
            .SetStatusCode(201);
    
    public static Result<TData> Updated() =>
        new Result<TData>()
            .SetSuccess(true)
            .SetStatusCode(204);

    public static Result<TData> Bad() =>
        new Result<TData>()
            .SetStatusCode(400);

    public static Result<TData> Bad(string message) =>
        new Result<TData>()
            .SetMessage(message)
            .SetStatusCode(400);

    
    public static Result<TData> NotFound(string message) =>
        new Result<TData>()
            .SetMessage(message)
            .SetStatusCode(404);
    
    public static new Result<TData> Fail() => new Result<TData>()
        .SetStatusCode(500);

    public static new Result<TData> Fail(string message) => new Result<TData>()
        .SetStatusCode(500)
        .SetMessage(message);
    
    
    #region fluent setters

    private Result<TData> SetData(TData data)
    {
        Data = data;
        return this;
    }

    private Result<TData> SetMessage(string message)
    {
        Message = message;
        return this;
    }
    
    protected Result<TData> SetSuccess(bool success)
    {
        Success = success;
        return this;
    }

    private Result<TData> SetStatusCode(int code)
    {
        StatusCode = code;
        return this;
    }

    #endregion
}