using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeDocAI.API.Data;
using SafeDocAI.API.DTOs;
using SafeDocAI.API.Models;

namespace SafeDocAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnidadesController : ControllerBase
{
    private readonly AppDbContext _context;

    public UnidadesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UnidadeDto>>> Listar()
    {
        var unidades = await _context.Unidades
            .Select(u => new UnidadeDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Cnpj = u.Cnpj,
                Cidade = u.Cidade,
                Estado = u.Estado,
                Ativa = u.Ativa
            })
            .ToListAsync();

        return Ok(unidades);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DetalheUnidadeDto>> BuscarPorId(int id)
    {
        var unidade = await _context.Unidades
            .Include(u => u.Documentos)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (unidade == null)
            return NotFound(new { mensagem = "Unidade não encontrada." });

        var dto = new DetalheUnidadeDto
        {
            Id = unidade.Id,
            Nome = unidade.Nome,
            Cnpj = unidade.Cnpj,
            Cidade = unidade.Cidade,
            Estado = unidade.Estado,
            Ativa = unidade.Ativa,
            Documentos = unidade.Documentos.Select(d => new DocumentoDto
            {
                Id = d.Id,
                Nome = d.Nome,
                DataEmissao = d.DataEmissao,
                DataValidade = d.DataValidade,
                Status = d.Status.ToString(),
                UnidadeId = d.UnidadeId
            }).ToList()
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Criar(CriarUnidadeDto dto)
    {
        var unidade = new Unidade
        {
            Nome = dto.Nome,
            Cnpj = dto.Cnpj,
            Cidade = dto.Cidade,
            Estado = dto.Estado,
            Ativa = dto.Ativa
        };

        _context.Unidades.Add(unidade);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(BuscarPorId), new { id = unidade.Id }, new
        {
            mensagem = "Unidade criada com sucesso.",
            id = unidade.Id
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, AtualizarUnidadeDto dto)
    {
        var unidade = await _context.Unidades.FindAsync(id);

        if (unidade == null)
            return NotFound(new { mensagem = "Unidade não encontrada." });

        unidade.Nome = dto.Nome;
        unidade.Cnpj = dto.Cnpj;
        unidade.Cidade = dto.Cidade;
        unidade.Estado = dto.Estado;
        unidade.Ativa = dto.Ativa;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remover(int id)
    {
        var unidade = await _context.Unidades.FindAsync(id);

        if (unidade == null)
            return NotFound(new { mensagem = "Unidade não encontrada." });

        _context.Unidades.Remove(unidade);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}