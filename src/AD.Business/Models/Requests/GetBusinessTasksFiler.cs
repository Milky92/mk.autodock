using AD.Persistence.Domain.Enums;

namespace AD.Business.Models.Requests;

public class GetBusinessTasksFiler
{
    public string Name { get; set; }
    public BusinessTaskStatus? Status { get; set; }
}