using System.Linq.Expressions;
using AD.Business.Models.Dto;
using AD.Business.Models.Requests;
using AD.Commons;
using AD.Persistence.DataAccess;
using AD.Persistence.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.GetAttachments;

public class GetAttachmentListQueryHandler : IRequestHandler<GetAttachmentListQuery, PagedResult<AttachmentGridItemDto>>
{
    private readonly ILogger<GetAttachmentListQueryHandler> _logger;
    private readonly AppDbContext _dbContext;

    public GetAttachmentListQueryHandler(ILogger<GetAttachmentListQueryHandler> logger, AppDbContext context)
    {
        _logger = logger;
        _dbContext = context;
    }

    public async Task<PagedResult<AttachmentGridItemDto>> Handle(GetAttachmentListQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var total = await _dbContext.Attachments.CountAsync(cancellationToken);
            
            var attachments = _dbContext.Attachments
                .Include(at => at.BusinessTask)
                .AsQueryable();

            if (request.Context.Filter != null)
                attachments = attachments.Where(GetPredicate(request.Context.Filter));
            
            var resList = await attachments
                .Select(at => new AttachmentGridItemDto
                {
                    ContentType = at.ContentType,
                    Name = at.Name,
                    Id = at.Id,
                    TaskId = at.BusinessTaskId,
                    TaskName = at.BusinessTask.Name
                })
                .Skip((request.Context.PageIndex - 1) * request.Context.CountOnPage)
                .Take(request.Context.CountOnPage).ToListAsync(cancellationToken);

            return PagedResult<AttachmentGridItemDto>.Ok(resList,
                request.Context.PageIndex,
                request.Context.CountOnPage, total);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not get business tasks by request. See exception. {@Request}", request);
            return PagedResult<AttachmentGridItemDto>.Failure(
                "Could not get business tasks by request. Internal error.");
        }
    }

    private Expression<Func<BusinessTaskAttachment, bool>> GetPredicate(AttachmentListFilter filter)
    {
        if (filter is null)
        {
            return null;
        }

        Expression<Func<BusinessTaskAttachment, bool>> expression = x =>
            filter.TaskId == null || x.BusinessTaskId == filter.TaskId &&
            string.IsNullOrEmpty(filter.ContentType) || x.ContentType == filter.ContentType &&
            string.IsNullOrEmpty(filter.TaskName) || x.BusinessTask.Name == filter.TaskName.Trim();

        return expression;
    }
}