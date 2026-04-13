using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeDocAI.API.Data;
using SafeDocAI.API.DTOs;
using SafeDocAI.API.Enums;

namespace SafeDocAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<DashboardDto>> ObterResumo()
    {
        var dto = new DashboardDto
        {
            TotalUnidades = await _context.Unidades.CountAsync(),
            DocumentosEmDia = await _context.Documentos.CountAsync(d => d.Status == StatusDocumento.EmDia),
            DocumentosVencendo = await _context.Documentos.CountAsync(d => d.Status == StatusDocumento.Vencendo),
            DocumentosVencidos = await _context.Documentos.CountAsync(d => d.Status == StatusDocumento.Vencido)
        };

        return Ok(dto);
    }
}