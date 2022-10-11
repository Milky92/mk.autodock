using System.ComponentModel.DataAnnotations;
using AD.Persistence.Domain.Models.Base;

namespace AD.Persistence.Domain.Models;

public class BusinessTaskAttachment : EntityBase
{
    [StringLength(128)] public string Name { get; set; }
    public int BusinessTaskId { get; set; }
    public BusinessTask BusinessTask { get; set; }
}