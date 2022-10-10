using AD.Business.Features.CreateBusinessTask;
using AD.Business.Features.DeleteBusinessTask;
using AD.Business.Features.UpdateBusinessTask;
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

    public BusinessTaskManager(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/task/create")]
    [ProducesResponseType(typeof(Result<CreateBusinessTaskResponse>), 200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateBusinessTask([FromBody] BusinessTaskRequest request,
        [FromForm] IFormFileCollection attachment,
        CancellationToken token)
    {
        var res = await _mediator.Send(request.Adapt<CreateBusinessTaskCommand>().WithFiles(attachment), token);
        return StatusCode(res.StatusCode, res);
    }


    [HttpPut("/task/{id:int}/update")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateBusinessTask([FromRoute] int id, [FromBody] BusinessTaskRequest request,
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
}