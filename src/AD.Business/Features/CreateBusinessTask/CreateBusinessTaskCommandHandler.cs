using System.Data;
using AD.Business.Models.Responses;
using AD.Commons;
using AD.Persistence.DataAccess;
using AD.Persistence.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.CreateBusinessTask;

public class
    CreateBusinessTaskCommandHandler : IRequestHandler<CreateBusinessTaskCommand, Result<CreateBusinessTaskResponse>>
{
    private readonly ILogger<CreateBusinessTaskCommandHandler> _logger;
    private readonly AppDbContext _dbContext;

    public CreateBusinessTaskCommandHandler(ILogger<CreateBusinessTaskCommandHandler> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
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
            _logger.LogInformation("Try create and save business task from request. {@Request}", request);
            var entity = request.Adapt<BusinessTask>();

            var res = await _dbContext.BusinessTasks.AddAsync(entity, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
            
            return Result<CreateBusinessTaskResponse>.Ok(res.Entity.Adapt<CreateBusinessTaskResponse>());
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(e,"Could not create new business task from request. See exception. {@Request}",request);
            return Result<CreateBusinessTaskResponse>.Fail("Could not create business task. Internal error.");
        }
    }

    private async ValueTask<bool> Exist(string name, CancellationToken token)
    {
        var task = await _dbContext.BusinessTasks.FirstOrDefaultAsync(t => t.Name == name, token);
        return task is not null;
    }
}