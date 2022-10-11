using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AD.Business.Services.Internals;

public class SimpleFileService : IFileService
{
    private const string DefaultContentType = "application/octet-stream";

    private readonly ILogger<SimpleFileService> _logger;
    private readonly FileStorageSettings _fileStorageSettings;

    public SimpleFileService(ILogger<SimpleFileService> logger, IOptions<FileStorageSettings> options)
    {
        _logger = logger;
        _fileStorageSettings = options.Value ?? throw new ArgumentNullException(nameof(FileStorageSettings));
    }

    public string GetContentType(string fileName) => GetMimeType(fileName);

    public async Task<bool> SaveRange(IFormFileCollection files, CancellationToken token)
    {
        //   bool hasSave = false;
        // if (!DirectoryHelper.CreateIfNotExists(_fileStorageSettings.PathToUpload))
        // {
        //     _logger.LogWarning("Could not create directory by specified path. {PathToUpload}",
        //         _fileStorageSettings.PathToUpload);
        //     return default;
        // }
        // files.AsParallel().ForAll(f =>
        // {
        //     
        //     
        //     
        // });

        foreach (var file in files)
        {
            var res = await SaveSingle(file, token);
            if (string.IsNullOrEmpty(res)) return false;
        }

        return true;
    }

    public async Task<string> SaveSingle(IFormFile file, CancellationToken token)
    {
        _logger.LogInformation("Try save file by specified path {PathToUpload}", _fileStorageSettings.PathToUpload);

        try
        {
            if (!DirectoryHelper.CreateIfNotExists(_fileStorageSettings.PathToUpload))
            {
                _logger.LogWarning("Could not create directory by specified path. {PathToUpload}",
                    _fileStorageSettings.PathToUpload);
                return default;
            }

            await using var contentStream = file.OpenReadStream();
            await using var fileStream = new FileStream(GetPath(file.FileName),
                new FileStreamOptions()
                {
                    Access = FileAccess.Write, Mode = FileMode.CreateNew, Options = FileOptions.Asynchronous
                });

            await contentStream.CopyToAsync(fileStream, token);

            return file.FileName;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not save file to specified path. See exception. {PathToUpload}",
                _fileStorageSettings.PathToUpload);
            return default;
        }
    }

    public async Task<(string, Stream)> GetFile(string fileName, CancellationToken token)
    {
        _logger.LogInformation("Try get file by specified path {PathToUpload}", _fileStorageSettings.PathToUpload);
        try
        {
            var content = (Stream)new FileStream(GetPath(fileName),
                new FileStreamOptions
                {
                    Mode = FileMode.Open,
                    Options =
                        FileOptions.Asynchronous,
                    Access = FileAccess.Read,
                });

            return await Task.FromResult((GetMimeType(fileName), content));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not get file from specified path. See exception. {PathToUpload}",
                _fileStorageSettings.PathToUpload);
            return (default, default);
        }
    }

    public async Task<bool> DeleteFile(string fileName, CancellationToken token)
    {
        try
        {
            await Task.Run(() =>
            {
                var path = GetPath(fileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }, token);

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not delete file form disc.");
            return false;
        }
    }

    public async Task<bool> DeleteRange(IEnumerable<string> files, CancellationToken token)
    {
        files.AsParallel().ForAll((f) =>
        {
            if (File.Exists(f))
                File.Delete(f);
        });

        return true;
    }

    private string GetPath(string fileName) => Path.Combine(_fileStorageSettings.PathToUpload, fileName);

    private static string GetMimeType(string filename)
        => new FileExtensionContentTypeProvider()
            .TryGetContentType(filename, out var contentType)
            ? contentType
            : DefaultContentType;
}