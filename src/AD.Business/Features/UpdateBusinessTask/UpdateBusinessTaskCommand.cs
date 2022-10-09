using AD.Commons;
using AD.Persistence.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace AD.Business.Features.UpdateBusinessTask;

public class UpdateBusinessTaskCommand:IRequest<Result>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public BusinessTaskStatus Status { get; set; }

    public UpdateBusinessTaskCommand WithId(int id)
    {
        Id = id;
        return this;
    }
}