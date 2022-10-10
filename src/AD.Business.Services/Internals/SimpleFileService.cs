using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AD.Business.Services.Internals;

public class SimpleFileService : IFileService
{
    private readonly ILogger<SimpleFileService> _logger;
    private readonly FileStorageSettings _fileStorageSettings;

    public SimpleFileService(ILogger<SimpleFileService> logger, IOptions<FileStorageSettings> options)
    {
        _logger = logger;
        _fileStorageSettings = options.Value ?? throw new ArgumentNullException(nameof(FileStorageSettings));
    }

    public Task<List<string>> SaveRange(IFormFileCollection files, CancellationToken token)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    private string GetPath(string fileName) => Path.Combine(_fileStorageSettings.PathToUpload, fileName);
}