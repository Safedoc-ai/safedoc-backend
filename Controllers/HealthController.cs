using Microsoft.AspNetCore.Mvc;

namespace SafeDocAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "OK",
            message = "API SafeDocAI funcionando"
        });
    }
}