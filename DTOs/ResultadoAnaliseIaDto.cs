namespace SafeDocAI.API.DTOs;

public class ResultadoAnaliseIaDto
{
    public string Status { get; set; } = string.Empty;
    public DateTime DataValidadeSugerida { get; set; }
    public string TipoDocumento { get; set; } = string.Empty;
    public string CnpjDetectado { get; set; } = string.Empty;
    public string OrgaoEmissor { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
}