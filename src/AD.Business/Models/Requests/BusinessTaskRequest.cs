using AD.Persistence.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace AD.Business.Models.Requests;

public class BusinessTaskRequest
{
    public string Name { get; set; }
}

public class CreateBusinessTaskRequest : BusinessTaskRequest
{
    public IFormFileCollection Files { get; set; }
}

public class UpdateBusinessTaskRequest : BusinessTaskRequest
{
    public BusinessTaskStatus Status { get; set; }
}