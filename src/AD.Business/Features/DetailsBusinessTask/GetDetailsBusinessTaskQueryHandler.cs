using AD.Business.Models.Dto;
using AD.Business.Models.Responses;
using AD.Commons;
using AD.Persistence.DataAccess;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.DetailsBusinessTask;

public class GetDetailsBusinessTaskQueryHandler : IRequestHandler<GetDetailsBusinessTaskQuery, Result<BusinessTaskDto>>
{
    private readonly ILogger<GetDetailsBusinessTaskQueryHandler> _logger;
    private readonly AppDbContext _dbContext;

    public GetDetailsBusinessTaskQueryHandler(ILogger<GetDetailsBusinessTaskQueryHandler> logger,
        AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<Result<BusinessTaskDto>> Handle(GetDetailsBusinessTaskQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var bTask = await _dbContext.BusinessTasks
                .Include(at => at.Attachments)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (bTask is null)
            {
                _logger.LogWarning("Business task not found. {@Request}",request);
                return Result<BusinessTaskDto>.NotFound("Business task not found.");
            }
            
            return Result<BusinessTaskDto>.Ok(bTask.Adapt<BusinessTaskDto>());
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Could not get  business task details from request. See exception. {@Request}", request);
            return Result<BusinessTaskDto>.Fail("Could not get   business task details. Internal error.");
        }
    }
}