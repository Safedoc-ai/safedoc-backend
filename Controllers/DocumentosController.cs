using Microsoft.AspNetCore.Mvc;

namespace SafeDocAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentosController : ControllerBase
{
    [HttpGet]
    public IActionResult Listar()
    {
        return Ok(new
        {
            mensagem = "Controller de documentos funcionando."
        });
    }
}