using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeDocAI.API.Data;
using SafeDocAI.API.DTOs;
using SafeDocAI.API.Enums;
using SafeDocAI.API.Models;
using SafeDocAI.API.Services;

namespace SafeDocAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentosController : ControllerBase
{
    private readonly AppDbContext _context;
private readonly StatusDocumentoService _statusService;

public DocumentosController(AppDbContext context, StatusDocumentoService statusService)
{
    _context = context;
    _statusService = statusService;
}

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocumentoDto>>> Listar()
    {
        var documentos = await _context.Documentos
            .Select(d => new DocumentoDto
            {
                Id = d.Id,
                Nome = d.Nome,
                DataEmissao = d.DataEmissao,
                DataValidade = d.DataValidade,
                Status = d.Status.ToString(),
                UnidadeId = d.UnidadeId
            })
            .ToListAsync();

        return Ok(documentos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DocumentoDto>> BuscarPorId(int id)
    {
        var documento = await _context.Documentos.FindAsync(id);

        if (documento == null)
            return NotFound(new { mensagem = "Documento não encontrado." });

        var dto = new DocumentoDto
        {
            Id = documento.Id,
            Nome = documento.Nome,
            DataEmissao = documento.DataEmissao,
            DataValidade = documento.DataValidade,
            Status = documento.Status.ToString(),
            UnidadeId = documento.UnidadeId
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Criar(CriarDocumentoDto dto)
    {
        var unidadeExiste = await _context.Unidades.AnyAsync(u => u.Id == dto.UnidadeId);

        if (!unidadeExiste)
            return BadRequest(new { mensagem = "Unidade informada não existe." });

        var documento = new Documento
        {
            Nome = dto.Nome,
            DataEmissao = dto.DataEmissao,
            DataValidade = dto.DataValidade,
            UnidadeId = dto.UnidadeId,
            Status = _statusService.CalcularStatus(dto.DataValidade)
        };

        _context.Documentos.Add(documento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = documento.Id }, new
        {
            mensagem = "Documento criado com sucesso.",
            id = documento.Id
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, CriarDocumentoDto dto)
    {
        var documento = await _context.Documentos.FindAsync(id);

        if (documento == null)
            return NotFound(new { mensagem = "Documento não encontrado." });

        var unidadeExiste = await _context.Unidades.AnyAsync(u => u.Id == dto.UnidadeId);

        if (!unidadeExiste)
            return BadRequest(new { mensagem = "Unidade informada não existe." });

        documento.Nome = dto.Nome;
        documento.DataEmissao = dto.DataEmissao;
        documento.DataValidade = dto.DataValidade;
        documento.UnidadeId = dto.UnidadeId;
        documento.Status = _statusService.CalcularStatus(dto.DataValidade);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remover(int id)
    {
        var documento = await _context.Documentos.FindAsync(id);

        if (documento == null)
            return NotFound(new { mensagem = "Documento não encontrado." });

        _context.Documentos.Remove(documento);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}