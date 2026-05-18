using Microsoft.AspNetCore.Mvc;
using SafeDocAI.API.DTOs;

namespace SafeDocAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnaliseIAController : ControllerBase
{
    [HttpPost("mock")]
    public ActionResult<ResultadoAnaliseIaDto> AnalisarMock(AnaliseIaMockDto dto)
    {
        var hoje = DateTime.Today;
        var diasParaVencer = (dto.DataValidade.Date - hoje).Days;

        string status;

        if (dto.DataValidade.Date < hoje)
        {
            status = "Vencido";
        }
        else if (diasParaVencer <= 30)
        {
            status = "Vencendo";
        }
        else
        {
            status = "EmDia";
        }

        var resultado = new ResultadoAnaliseIaDto
        {
            Status = status,
            DataValidadeSugerida = dto.DataValidade,
            TipoDocumento = dto.NomeDocumento,
            CnpjDetectado = "12345678000100",
            OrgaoEmissor = "Órgão emissor simulado",
            Mensagem = "Análise mock realizada com sucesso. Nenhum OCR real foi executado."
        };

        return Ok(resultado);
    }
}