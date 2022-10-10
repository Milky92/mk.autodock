using System.ComponentModel.DataAnnotations;
using AD.Persistence.Domain.Enums;
using AD.Persistence.Domain.Models.Base;

namespace AD.Persistence.Domain.Models;

public class BusinessTask : EntityBase
{
    [StringLength(55)] public string Name { get; set; }
    public BusinessTaskStatus Status { get; set; }
    
    public virtual ICollection<BusinessTaskAttachment> Attachments { get; set; }
}