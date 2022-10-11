using AD.Business.Models.Dto;
using AD.Business.Services;
using AD.Commons;
using AD.Persistence.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.GetFile;

public class GetFileQueryHandler : IRequestHandler<GetFileQuery, Result<FileDto>>
{
    private readonly ILogger<GetFileQueryHandler> _logger;
    private readonly AppDbContext _appDbContext;
    private readonly IFileService _fileService;

    public GetFileQueryHandler(ILogger<GetFileQueryHandler> logger, AppDbContext appDbContext, IFileService fileService)
    {
        _logger = logger;
        _appDbContext = appDbContext;
        _fileService = fileService;
    }

    public async Task<Result<FileDto>> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bTask = await _appDbContext.BusinessTasks
                .Include(bt => bt.Attachments)
                .FirstOrDefaultAsync(bt => bt.Id == request.TaskId, cancellationToken);

            if (bTask is null)
            {
                _logger.LogWarning("Business task not found by specified identifier. {TaskId}", request.TaskId);
                return Result<FileDto>.NotFound("Business task not found.");
            }

            var attachment = bTask.Attachments.FirstOrDefault(a => a.Id == request.AttachmentId);
            if (attachment is null)
            {
                _logger.LogWarning("Attachment not found by specified task and file identifier. {TaskId} {FileId}",
                    request.TaskId, request.AttachmentId);
                return Result<FileDto>.NotFound("Attachment not found.");
            }

            var (contentType, content) = await _fileService.GetFile(attachment.Name, cancellationToken);

            if (string.IsNullOrEmpty(contentType) || content is null)
            {
                _logger.LogWarning("Attachment file not found by specified task and file identifier. {TaskId} {FileId}",
                    request.TaskId, request.AttachmentId);
                return Result<FileDto>.NotFound("Attachment not found.");
            }

            return Result<FileDto>.Ok(new FileDto(contentType, content, attachment.Name));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not get file by specified task. See exception. {FileId} {TaskId}",
                request.AttachmentId, request.TaskId);
            return Result<FileDto>.Fail("Could not get file by specified task. Internal error.");
        }
    }
}