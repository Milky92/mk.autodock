using AD.Business.Models.Dto;
using AD.Business.Services;
using AD.Commons;
using AD.Persistence.DataAccess;
using AD.Persistence.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.UploadFiles;

public class UploadFilesCommandHandler : IRequestHandler<UploadFilesCommand, Result<AttachmentDto>>
{
    private readonly ILogger<UploadFilesCommandHandler> _logger;
    private readonly AppDbContext _dbContext;
    private readonly IFileService _fileService;

    public UploadFilesCommandHandler(ILogger<UploadFilesCommandHandler> logger,
        AppDbContext dbContext,
        IFileService fileService)
    {
        _logger = logger;
        _dbContext = dbContext;
        _fileService = fileService;
    }

    public async Task<Result<AttachmentDto>> Handle(UploadFilesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await using var dbTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            var resultStore = await StoreAttachment(request, dbTransaction, cancellationToken);

            if (!resultStore.Success)
                return resultStore;

            var resultSaveFile = await SaveFile(request, dbTransaction, cancellationToken);

            if (!resultSaveFile.Success)
                return Result<AttachmentDto>.Fail(resultSaveFile.Message);

            await dbTransaction.CommitAsync(cancellationToken);
            
            return Result<AttachmentDto>.Ok(resultStore.Data);
        }
        catch (Exception e)
        {
            _logger.LogError(e?.InnerException ?? e, "Could not finish db transaction. See exception. {TaskId}",
                request.TaskId);
            return Result<AttachmentDto>.Fail("Could not attach file to specified task. Internal error.");
        }
    }


    private async Task<Result<AttachmentDto>> StoreAttachment(UploadFilesCommand request,
        IDbContextTransaction dbTransaction, CancellationToken cancellationToken)
    {
        try
        {
            var bTask = await _dbContext.BusinessTasks.FirstOrDefaultAsync(x => x.Id == request.TaskId,
                cancellationToken);

            if (bTask is null)
            {
                _logger.LogWarning("Task not found by specified identifier. {TaskId}", request.TaskId);
                return Result<AttachmentDto>.NotFound("Task not found.");
            }

            var attachment = new BusinessTaskAttachment { Name = request.File.FileName, BusinessTaskId = bTask.Id, };

            await _dbContext.Attachments.AddAsync(attachment, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<AttachmentDto>.Ok(attachment.Adapt<AttachmentDto>());
        }
        catch (Exception e)
        {
            await dbTransaction.RollbackAsync(cancellationToken);
            _logger.LogError(e, "Could not attach file to task. See exception. {TaskId}", request.TaskId);
            return Result<AttachmentDto>.Fail("Could not attach file to specified task. Please try later");
        }
    }

    private async Task<Result<string>> SaveFile(UploadFilesCommand request,
        IDbContextTransaction dbTransaction, CancellationToken cancellationToken)
    {
        try
        {
            var fileName = await _fileService.SaveSingle(request.File, cancellationToken);

            if (string.IsNullOrEmpty(fileName))
            {
                return Result<string>.Bad("Could not save file for specified task.");
            }

            return Result<string>.Ok(fileName);
        }
        catch (Exception e)
        {
            await dbTransaction.RollbackAsync(cancellationToken);
            _logger.LogError(e, "Could not save file from request. See exception. {TaskId}", request.TaskId);
            return Result<string>.Fail("Could not save file for specified task. Internal error.");
        }
    }
}