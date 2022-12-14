using Microsoft.AspNetCore.Http;

namespace AD.Business.Services;

public interface IFileService
{
    Task<bool> SaveRange(IFormFileCollection files, CancellationToken token);
    
    Task<string> SaveSingle(IFormFile file, CancellationToken token);

    /// <summary>
    /// Return file stream with mime type.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<(string, Stream)> GetFile(string fileName, CancellationToken token);

    Task<bool> DeleteFile(string fileName, CancellationToken token);

    Task<bool> DeleteRange(IEnumerable<string> files, CancellationToken token);
    string GetContentType(string fileName);
}