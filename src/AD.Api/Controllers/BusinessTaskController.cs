using AD.Business.Features.DetailsBusinessTask;
using AD.Business.Features.ListBusinessTask;
using AD.Business.Models.Dto;
using AD.Business.Models.Requests;
using AD.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AD.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessTaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public BusinessTaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/page")]
    [ProducesResponseType(typeof(PagedResult<BusinessTaskItemGridDto>), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Page([FromBody] PageContext<GetBusinessTasksFiler> request,
        CancellationToken token)
    {
        var res = await _mediator.Send(new GetListBusinessTasksQuery(request), token);

        return StatusCode(res.StatusCode, res);
    }

    [HttpPost("{id:int}")]
    [ProducesResponseType(typeof(Result<BusinessTaskDto>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Details([FromRoute] int id, CancellationToken token)
    {
        var res = await _mediator.Send(new GetDetailsBusinessTaskQuery { Id = id }, token);

        return StatusCode(res.StatusCode, res);
    }
}