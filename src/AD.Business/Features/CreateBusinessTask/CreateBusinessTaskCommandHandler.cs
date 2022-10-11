using System.Data;
using AD.Business.Models.Responses;
using AD.Business.Services;
using AD.Commons;
using AD.Persistence.DataAccess;
using AD.Persistence.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.CreateBusinessTask;

public class
    CreateBusinessTaskCommandHandler : IRequestHandler<CreateBusinessTaskCommand, Result<CreateBusinessTaskResponse>>
{
    private readonly ILogger<CreateBusinessTaskCommandHandler> _logger;
    private readonly AppDbContext _dbContext;
    private readonly IFileService _fileService;

    public CreateBusinessTaskCommandHandler(ILogger<CreateBusinessTaskCommandHandler> logger, AppDbContext dbContext,
        IFileService fileService)
    {
        _logger = logger;
        _dbContext = dbContext;
        _fileService = fileService;
    }

    public async Task<Result<CreateBusinessTaskResponse>> Handle(CreateBusinessTaskCommand request,
        CancellationToken cancellationToken)
    {
        var exist = await Exist(request.Name, cancellationToken);
        if (exist)
        {
            _logger.LogWarning("Could not create task with same name. {@Request}", request);
            return Result<CreateBusinessTaskResponse>.Bad("Could not create task with same name.");
        }

        await using var transaction =
            await _dbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

        try
        {
            _logger.LogInformation("Try create and save business task from request. Attached files: {CountFiles} . {TaskName}",
                request.Name,
                request.FileInfo.Files.Count);

            var bTask = await StoreTask(request, cancellationToken);

            await StoreAttachments(request.FileInfo.Files, bTask.Entity.Id, cancellationToken);

            var res = await _fileService.SaveRange(request.FileInfo.Files, cancellationToken);

            if (!res)
            {
                await transaction.RollbackAsync(cancellationToken);
                return Result<CreateBusinessTaskResponse>.Bad("Could not upload attached files. Task was not created.");
            }

            await transaction.CommitAsync(cancellationToken);

            return Result<CreateBusinessTaskResponse>.Ok(bTask.Entity.Adapt<CreateBusinessTaskResponse>());
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(e, "Could not create new business task from request. See exception. {@Request}", request);
            return Result<CreateBusinessTaskResponse>.Fail("Could not create business task. Internal error.");
        }
    }

    private async ValueTask<bool> Exist(string name, CancellationToken token)
    {
        var task = await _dbContext.BusinessTasks.FirstOrDefaultAsync(t => t.Name == name, token);
        return task is not null;
    }

    private async Task<EntityEntry<BusinessTask>> StoreTask(CreateBusinessTaskCommand command, CancellationToken token)
    {
        var entity = command.Adapt<BusinessTask>();

        var bTask = await _dbContext
            .BusinessTasks
            .AddAsync(entity, token);

        await _dbContext.SaveChangesAsync(token);

        return bTask;
    }

    private async Task StoreAttachments(IFormFileCollection files, int taskId, CancellationToken token)
    {
        var attachments = new List<BusinessTaskAttachment>();

        files.AsParallel().ForAll(f =>
        {
            attachments.Add(new BusinessTaskAttachment()
            {
                BusinessTaskId = taskId, Name = f.FileName, ContentType = f.ContentType
            });
        });

        await _dbContext.Attachments.AddRangeAsync(attachments, token);

        await _dbContext.SaveChangesAsync(token);
    }
}