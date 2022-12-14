using System.Data;
using AD.Business.Services;
using AD.Commons;
using AD.Persistence.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.DeleteBusinessTask;

public class DeleteBusinessTaskCommandHandler : IRequestHandler<DeleteBusinessTaskCommand, Result>
{
    private readonly ILogger<DeleteBusinessTaskCommandHandler> _logger;
    private readonly AppDbContext _dbContext;
    private readonly IFileService _fileService;
    public DeleteBusinessTaskCommandHandler(ILogger<DeleteBusinessTaskCommandHandler> logger, AppDbContext dbContext,IFileService fileService)
    {
        _logger = logger;
        _dbContext = dbContext;
        _fileService = fileService;
    }

    public async Task<Result> Handle(DeleteBusinessTaskCommand request, CancellationToken cancellationToken)
    {
        await using var transaction =
            await _dbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            var bTask = await _dbContext.BusinessTasks
                .Include(bt=>bt.Attachments)
                .FirstOrDefaultAsync(bt => bt.Id == request.Id,
                cancellationToken);

            if (bTask is null)
            {
                _logger.LogWarning("Business task not found. {@Request}", request);
                return Result.NotFound("Business task not found.");
            }

            var files = bTask.Attachments.Select(x => x.Name).ToList();
            
            _dbContext.BusinessTasks.Remove(bTask);

             if (_dbContext.Attachments.Any())
            {
                _dbContext.Attachments.RemoveRange();

                await _fileService.DeleteRange(files, cancellationToken);
            }
            
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            await transaction.CommitAsync(cancellationToken);
            
            return Result.Ok();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(e, "Could not delete business task. See exceptions. {@Request}", request);
            return Result.Fail("Could not delete business task. Internal error.");
        }
    }
}