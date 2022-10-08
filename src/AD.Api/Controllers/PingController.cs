using Microsoft.AspNetCore.Mvc;

namespace AD.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController:ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] string parameter)
    {
        return await Task.FromResult<IActionResult>(Ok(parameter));
    }
}