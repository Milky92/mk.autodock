using AD.Business.Services;
using AD.Commons;
using AD.Persistence.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.DeleteFile;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, Result>
{
    private readonly ILogger<DeleteFileCommandHandler> _logger;
    private readonly AppDbContext _dbContext;
    private readonly IFileService _fileService;

    public DeleteFileCommandHandler(ILogger<DeleteFileCommandHandler> logger, AppDbContext dbContext,
        IFileService fileService)
    {
        _logger = logger;
        _dbContext = dbContext;
        _fileService = fileService;
    }

    public async Task<Result> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        await using var dbTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var bTask = await _dbContext.BusinessTasks
                .Include(t => t.Attachments)
                .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);

            if (bTask is null)
            {
                return Result.NotFound("Business task not found.");
            }

            var attachment = bTask.Attachments.FirstOrDefault(f => f.Id == request.AttachmentId);

            if (attachment is null)
            {
                return Result.NotFound("Attachment not found");
            }

            _dbContext.Attachments.Remove(attachment);

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            var res = await _fileService.DeleteFile(attachment.Name, cancellationToken);
            if (!res)
                return Result.Fail("Could not delete attachment.");

            await dbTransaction.CommitAsync(cancellationToken);
            
            return Result.Updated();
        }
        catch (Exception e)
        {
            await dbTransaction.RollbackAsync(cancellationToken);
            _logger.LogError(e,"Could not delete file by specified task and file identifier. {TaskId} {FileId}",
                request.TaskId, request.AttachmentId);
            return Result.Fail("Could not delete attachment.");
        }
    }
}