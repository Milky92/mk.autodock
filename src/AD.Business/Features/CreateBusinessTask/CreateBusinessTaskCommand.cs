using AD.Business.Models.Responses;
using AD.Commons;
using AD.Persistence.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AD.Business.Features.CreateBusinessTask;

public class CreateBusinessTaskCommand:IRequest<Result<CreateBusinessTaskResponse>>
{
    public string Name { get; set; }
    public BusinessTaskStatus Status { get; set; }
    
    public IFormFileCollection Attachment { get; private set; }

    public CreateBusinessTaskCommand WithFiles(IFormFileCollection attachment)
    {
        Attachment = attachment;
        return this;
    }
}