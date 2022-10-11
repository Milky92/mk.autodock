using AD.Business.Features.DetailsBusinessTask;
using AD.Business.Features.ListBusinessTask;
using AD.Business.Models.Dto;
using AD.Business.Models.Requests;
using AD.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    /// <summary>
    /// Grid business task.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost("page")]
    [SwaggerOperation(Summary = "Get tasks")]
    [ProducesResponseType(typeof(PagedResult<BusinessTaskItemGridDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Page([FromBody] PageContext<GetBusinessTasksFiler> request,
        CancellationToken token)
    {
        var res = await _mediator.Send(new GetListBusinessTasksQuery(request), token);

        return StatusCode(res.StatusCode, res);
    }
    
    /// <summary>
    /// Details data for business task
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost("{id:int}")]
    [SwaggerOperation(Summary = "Get detail task")]
    [ProducesResponseType(typeof(Result<BusinessTaskDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Details([FromRoute] int id, CancellationToken token)
    {
        var res = await _mediator.Send(new GetDetailsBusinessTaskQuery { Id = id }, token);

        return StatusCode(res.StatusCode, res);
    }
}