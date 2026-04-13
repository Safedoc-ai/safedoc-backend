using SafeDocAI.API.Enums;

namespace SafeDocAI.API.Models;

public class Documento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public DateTime DataEmissao { get; set; }
    public DateTime DataValidade { get; set; }

    public StatusDocumento Status { get; set; }

    public int UnidadeId { get; set; }
    public Unidade Unidade { get; set; } = null!;
}