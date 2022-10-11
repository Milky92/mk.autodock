using AD.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace AD.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController:ControllerBase
{
    public IFileService _fileService;
    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string fileName,CancellationToken token)
    {
        var (contentType,stream) = await _fileService.GetFile(fileName, token);
        
        if (stream is null)
            return NotFound();
        
        return File(stream, contentType);
    }
}