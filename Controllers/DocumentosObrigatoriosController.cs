using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeDocAI.API.Data;
using SafeDocAI.API.DTOs;
using SafeDocAI.API.Models;

namespace SafeDocAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentosObrigatoriosController : ControllerBase
{
    private readonly AppDbContext _context;

    public DocumentosObrigatoriosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocumentoObrigatorioDto>>> Listar()
    {
        var documentos = await _context.DocumentosObrigatorios
            .Select(d => new DocumentoObrigatorioDto
            {
                Id = d.Id,
                Nome = d.Nome,
                Frequencia = d.Frequencia
            })
            .ToListAsync();

        return Ok(documentos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DocumentoObrigatorioDto>> BuscarPorId(int id)
    {
        var documento = await _context.DocumentosObrigatorios.FindAsync(id);

        if (documento == null)
        {
            return NotFound(new { mensagem = "Documento obrigatório não encontrado." });
        }

        var dto = new DocumentoObrigatorioDto
        {
            Id = documento.Id,
            Nome = documento.Nome,
            Frequencia = documento.Frequencia
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Criar(CriarDocumentoObrigatorioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
        {
            return BadRequest(new { mensagem = "O nome do documento é obrigatório." });
        }

        if (string.IsNullOrWhiteSpace(dto.Frequencia))
        {
            return BadRequest(new { mensagem = "A frequência é obrigatória." });
        }

        var documento = new DocumentoObrigatorio
        {
            Nome = dto.Nome,
            Frequencia = dto.Frequencia
        };

        _context.DocumentosObrigatorios.Add(documento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = documento.Id }, new
        {
            mensagem = "Documento obrigatório criado com sucesso.",
            id = documento.Id
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, AtualizarDocumentoObrigatorioDto dto)
    {
        var documento = await _context.DocumentosObrigatorios.FindAsync(id);

        if (documento == null)
        {
            return NotFound(new { mensagem = "Documento obrigatório não encontrado." });
        }

        if (string.IsNullOrWhiteSpace(dto.Nome))
        {
            return BadRequest(new { mensagem = "O nome do documento é obrigatório." });
        }

        if (string.IsNullOrWhiteSpace(dto.Frequencia))
        {
            return BadRequest(new { mensagem = "A frequência é obrigatória." });
        }

        documento.Nome = dto.Nome;
        documento.Frequencia = dto.Frequencia;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remover(int id)
    {
        var documento = await _context.DocumentosObrigatorios.FindAsync(id);

        if (documento == null)
        {
            return NotFound(new { mensagem = "Documento obrigatório não encontrado." });
        }

        _context.DocumentosObrigatorios.Remove(documento);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}