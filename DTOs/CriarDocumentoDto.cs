namespace SafeDocAI.API.DTOs;

public class CriarDocumentoDto
{
    public string Nome { get; set; } = string.Empty;
    public DateTime DataEmissao { get; set; }
    public DateTime DataValidade { get; set; }
    public int UnidadeId { get; set; }
}