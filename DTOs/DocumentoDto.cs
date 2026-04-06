namespace SafeDocAI.API.DTOs;

public class DocumentoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataValidade { get; set; }
    public string Status { get; set; } = string.Empty;
}