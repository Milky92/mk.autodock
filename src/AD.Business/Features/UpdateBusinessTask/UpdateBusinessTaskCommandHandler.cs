using System.Data;
using AD.Commons;
using AD.Persistence.DataAccess;
using AD.Persistence.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.UpdateBusinessTask;

public class UpdateBusinessTaskCommandHandler : IRequestHandler<UpdateBusinessTaskCommand, Result>
{
    private readonly ILogger<UpdateBusinessTaskCommandHandler> _logger;
    private readonly AppDbContext _dbContext;

    public UpdateBusinessTaskCommandHandler(ILogger<UpdateBusinessTaskCommandHandler> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<Result> Handle(UpdateBusinessTaskCommand request, CancellationToken cancellationToken)
    {
        
        await using var transaction =
            await _dbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
        try
        {
            var bTask = await _dbContext.BusinessTasks.FirstOrDefaultAsync(bt => bt.Id == request.Id, cancellationToken);

            if (bTask is null)
            {
                _logger.LogWarning("Task entity not found. {@Request}",request);
                return Result.NotFound("Task not found.");
            }
            
            UpdateBusinessTask(bTask,request);

            await _dbContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
            
            return Result.Updated();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            
            _logger.LogError(e,"Could not update business task from request. See exception. {@Request}",request);
            return Result.Fail("Could not update business task. Internal error.");
        }
    }


    public void UpdateBusinessTask(BusinessTask btask,UpdateBusinessTaskCommand request)
    {
        if (!string.IsNullOrEmpty(request.Name))
            btask.Name = request.Name;

        if (btask.Status != request.Status)
            btask.Status = request.Status;
    }

}