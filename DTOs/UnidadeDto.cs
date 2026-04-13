namespace SafeDocAI.API.DTOs;

public class UnidadeDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public bool Ativa { get; set; }
}