using AD.Business.Models.Responses;
using AD.Commons;
using AD.Persistence.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AD.Business.Features.CreateBusinessTask;

public class CreateBusinessTaskCommand:IRequest<Result<CreateBusinessTaskResponse>>
{
    public string Name { get; set; }
}