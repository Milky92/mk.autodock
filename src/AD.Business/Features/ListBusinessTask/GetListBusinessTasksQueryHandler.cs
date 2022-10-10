using System.Linq.Expressions;
using AD.Business.Models.Dto;
using AD.Business.Models.Requests;
using AD.Commons;
using AD.Persistence.DataAccess;
using AD.Persistence.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.ListBusinessTask;

public class
    GetListBusinessTasksQueryHandler : IRequestHandler<GetListBusinessTasksQuery, PagedResult<BusinessTaskItemGridDto>>
{
    private readonly ILogger<GetListBusinessTasksQueryHandler> _logger;
    private readonly AppDbContext _dbContext;

    public GetListBusinessTasksQueryHandler(ILogger<GetListBusinessTasksQueryHandler> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<PagedResult<BusinessTaskItemGridDto>> Handle(GetListBusinessTasksQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var bTasks = _dbContext.BusinessTasks.AsQueryable();

            if (request.Context.Filter != null)
                bTasks = bTasks.Where(GetPredicate(request.Context.Filter));

            var total = await _dbContext.BusinessTasks.CountAsync(cancellationToken);

            var resList = await bTasks
                .Skip((request.Context.PageIndex - 1) * request.Context.CountOnPage)
                .Take(request.Context.CountOnPage).ToListAsync(cancellationToken);
 
            return PagedResult<BusinessTaskItemGridDto>.Ok(resList.Adapt<IEnumerable<BusinessTaskItemGridDto>>(),
                request.Context.PageIndex,
                request.Context.CountOnPage, total);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not get business tasks by request. See exception. {@Request}", request);
            return PagedResult<BusinessTaskItemGridDto>.Failure(
                "Could not get business tasks by request. Internal error.");
        }
    }


    private Expression<Func<BusinessTask, bool>> GetPredicate(GetBusinessTasksFiler filter)
    {
        if (filter is null)
        {
            return null;
        }

        Expression<Func<BusinessTask, bool>> expression = x =>
            string.IsNullOrEmpty(filter.Name) || x.Name == filter.Name.Trim() &&
            filter.Status == null || x.Status == filter.Status;

        return expression;
    }
}