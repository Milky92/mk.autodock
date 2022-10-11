using System.ComponentModel.DataAnnotations;
using AD.Persistence.Domain.Models.Base;

namespace AD.Persistence.Domain.Models;

public class BusinessTaskAttachment : EntityBase
{
    [StringLength(512)] public string Name { get; set; }
    [StringLength(128)] public string ContentType { get; set; }
    public int BusinessTaskId { get; set; }
    public BusinessTask BusinessTask { get; set; }
}