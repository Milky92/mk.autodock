namespace AD.Business.Models.Dto;

public class AttachmentGridItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContentType { get; set; }
    public string TaskName { get; set; }
    public int TaskId { get; set; }
}