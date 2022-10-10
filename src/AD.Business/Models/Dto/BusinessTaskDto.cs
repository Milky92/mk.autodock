using System.ComponentModel;
using AD.Persistence.Domain.Enums;

namespace AD.Business.Models.Dto;

public class BusinessTaskDto:BusinessTaskDtoBase
{
    public string Name { get; set; }
    public BusinessTaskStatus Status { get; set; }
    public DateTime DateTimeCreation { get; set; }
    public DateTime DateTimeUpdate { get; set; }
}