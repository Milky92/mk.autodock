using AD.Api.Attributes;
using AD.Business.Features.CreateBusinessTask;
using AD.Business.Features.DeleteBusinessTask;
using AD.Business.Features.UpdateBusinessTask;
using AD.Business.Features.UploadFiles;
using AD.Business.Models.Dto;
using AD.Business.Models.Requests;
using AD.Business.Models.Responses;
using AD.Commons;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AD.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessTaskManager : ControllerBase
{
    private readonly IMediator _mediator;
    private const int UploadSizeLimit = 100 * 1024 * 1024;

    public BusinessTaskManager(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create business task.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost("/task/create")]
    [ProducesResponseType(typeof(Result<CreateBusinessTaskResponse>), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    
    public async Task<IActionResult> CreateBusinessTask([FromBody] BusinessTaskRequest request,
        CancellationToken token)
    {
        var res = await _mediator.Send(request.Adapt<CreateBusinessTaskCommand>(), token);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut("/task/{id:int}/update")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateBusinessTask(
        [FromRoute] int id,
        [FromBody] BusinessTaskRequest request,
        CancellationToken token)
    {
        var res = await _mediator.Send(request.Adapt<UpdateBusinessTaskCommand>().WithId(id), token);
        return StatusCode(res.StatusCode);
    }

    [HttpDelete("/task/{id:int}/delete")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> DeleteBusinessTask([FromRoute] int id, CancellationToken token)
    {
        var res = await _mediator.Send(new DeleteBusinessTaskCommand(id), token);
        return StatusCode(res.StatusCode);
    }

    [HttpPost("/task/{taskId:int}/file")]
    [Consumes("multipart/form-data")]
    [DisableRequestSizeLimit,
     RequestFormLimits(MultipartBodyLengthLimit = UploadSizeLimit, ValueLengthLimit = UploadSizeLimit)]
    [ProducesResponseType(type: typeof(Result<AttachmentDto>), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> UploadFile([FromRoute] int taskId,
        CancellationToken token)
    {
        var file = Request.Form.Files.FirstOrDefault();

        if (file is null)
            return StatusCode(404, "File not specified.");

        var res = await _mediator.Send(new UploadFilesCommand(taskId, file), token);
        return StatusCode(res.StatusCode);
    }
}