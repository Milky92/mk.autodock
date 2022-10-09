using AD.Business.Features.CreateBusinessTask;
using AD.Business.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AD.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessTaskManager:ControllerBase
{
    private readonly IMediator _mediator;
    
    public BusinessTaskManager(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateBusinessTaskResponse),200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateBusinessTask([FromBody]CreateBusinessTaskCommand request,CancellationToken token)
    {
        var res = await _mediator.Send(request, token);
        
        return StatusCode(res.StatusCode, res.Data);
    }
    
    
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateBusinessTask()
    {
        return Ok("");
    }
    
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> DeleteBusinessTask()
    {
        return Ok("");
    }
}