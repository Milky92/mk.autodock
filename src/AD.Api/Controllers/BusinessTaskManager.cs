using AD.Api.Consts;
using AD.Business.Features.CreateBusinessTask;
using AD.Business.Features.DeleteBusinessTask;
using AD.Business.Features.UpdateBusinessTask;
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
    [DisableRequestSizeLimit,
     RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue, ValueLengthLimit = RequestLimits.UploadLimit)]
    [ProducesResponseType(typeof(Result<CreateBusinessTaskResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateBusinessTask([FromForm] CreateBusinessTaskRequest request,
        CancellationToken token)
    {
        var res = await _mediator.Send(request.Adapt<CreateBusinessTaskCommand>().WithFiles(request.Files), token);
        return StatusCode(res.StatusCode, res);
    }

    /// <summary>
    /// Update business task
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPut("/task/{id:int}/update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBusinessTask(
        [FromRoute] int id,
        [FromBody] UpdateBusinessTaskRequest request,
        CancellationToken token)
    {
        var res = await _mediator.Send(request.Adapt<UpdateBusinessTaskCommand>().WithId(id), token);
        return StatusCode(res.StatusCode);
    }

    
    /// <summary>
    /// Delete business task
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpDelete("/task/{id:int}/delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBusinessTask([FromRoute] int id, CancellationToken token)
    {
        var res = await _mediator.Send(new DeleteBusinessTaskCommand(id), token);
        return StatusCode(res.StatusCode);
    }
}