namespace SafeDocAI.API.Models;

public class Documento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataValidade { get; set; }
    public string Status { get; set; } = string.Empty;
    public int UnidadeId { get; set; }
}