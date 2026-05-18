namespace SafeDocAI.API.DTOs;

public class AnaliseIaMockDto
{
    public string NomeDocumento { get; set; } = string.Empty;
    public DateTime DataEmissao { get; set; }
    public DateTime DataValidade { get; set; }
    public int UnidadeId { get; set; }
}