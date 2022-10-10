using AD.Business.Models.Dto;
using AD.Business.Models.Responses;
using AD.Commons;
using MediatR;

namespace AD.Business.Features.DetailsBusinessTask;

public class GetDetailsBusinessTaskQuery:IRequest<Result<BusinessTaskDto>>
{
    public int Id { get; set; }
}