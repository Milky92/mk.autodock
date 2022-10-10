using AD.Business.Models.Dto;
using AD.Business.Models.Requests;
using AD.Business.Models.Responses;
using AD.Commons;
using MediatR;

namespace AD.Business.Features.ListBusinessTask;

public class GetListBusinessTasksQuery:IRequest<PagedResult<BusinessTaskItemGridDto>>
{
    public GetListBusinessTasksQuery(PageContext<GetBusinessTasksFiler> context)
    {
        Context = context;
    }
    public PageContext<GetBusinessTasksFiler> Context { get; }
}