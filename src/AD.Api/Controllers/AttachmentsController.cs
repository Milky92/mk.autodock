using AD.Business.Features.DeleteFile;
using AD.Business.Features.GetAttachments;
using AD.Business.Features.GetFile;
using AD.Business.Features.UploadFiles;
using AD.Business.Models.Dto;
using AD.Business.Models.Requests;
using AD.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AD.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class AttachmentsController:ControllerBase
{
    private const int UploadSizeLimit = 100 * 1024 * 1024;
    
    private readonly IMediator _mediator;
    public AttachmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("page")]
    [SwaggerOperation(Summary = "Get attachments")]
    [ProducesResponseType(typeof(PagedResult<AttachmentGridItemDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPage(PageContext<AttachmentListFilter> context,CancellationToken token)
    {
        var res = await _mediator.Send(new GetAttachmentListQuery(context), token);
        return StatusCode(res.StatusCode, res);
    }

    /// <summary>
    /// Attach file into business task.
    /// </summary>
    /// <param name="taskId"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost("task/{taskId:int}/attachment")]
    [SwaggerOperation(Summary = "Attach to task")]
    [Consumes("multipart/form-data")]
    [DisableRequestSizeLimit,
     RequestFormLimits(MultipartBodyLengthLimit = UploadSizeLimit, ValueLengthLimit = UploadSizeLimit)]
    [ProducesResponseType(type: typeof(Result<AttachmentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UploadFileAttachment([FromRoute] int taskId,
        CancellationToken token)
    {
        var file = Request.Form.Files.FirstOrDefault();

        if (file is null)
            return StatusCode(StatusCodes.Status404NotFound, "File not specified.");

        var res = await _mediator.Send(new UploadFilesCommand(taskId, file), token);
        return StatusCode(res.StatusCode);
    }

    /// <summary>
    /// Download attachment file from business task.
    /// </summary>
    /// <param name="taskId">task identifier</param>
    /// <param name="attachmentId">attachment identifier</param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("task/{taskId:int}/attachment/{attachmentId:int}")]
    [SwaggerOperation(Summary = "Download attachment file")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<FileStreamResult> DownloadAttachmentFile([FromRoute] int taskId, [FromRoute] int attachmentId,
        CancellationToken token)
    {
        var res = await _mediator.Send(new GetFileQuery(taskId, attachmentId), token);
        if (!res.Success)
        {
            return new FileStreamResult(Stream.Null, "");
        }
        return new FileStreamResult(res.Data.Content, res.Data.ContentType) { FileDownloadName = res.Data.FileName };
    }

    /// <summary>
    /// Delete attachment.
    /// </summary>
    /// <param name="taskId">task identifier</param>
    /// <param name="attachmentId">file identifier</param>
    /// <param name="token">cancellation toke</param>
    /// <returns></returns>
    [HttpDelete("task/{taskId:int}/attachment/{attachmentId:int}")]
    [SwaggerOperation(Summary = "Delete attachment")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteFile(int taskId, int attachmentId, CancellationToken token)
    {
        var res = await _mediator.Send(new DeleteFileCommand(taskId, attachmentId), token);
        return StatusCode(res.StatusCode, res.Message);
    } 
}