namespace AD.Business.Models.Requests;

public class AttachmentListFilter
{
    public int? TaskId { get; set; }
    public string TaskName { get; set; }
    public string ContentType { get; set; }
}