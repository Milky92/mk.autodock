using AD.Business.Features.Ping;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AD.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController:ControllerBase
{
    private readonly IMediator _mediator;
    public PingController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]string p)
    {
        var res = await _mediator.Send(new PingCommand(p));
        return res.Success ? Ok(res.Data) : BadRequest(res.Message);
    }
}