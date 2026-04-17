using SafeDocAI.API.Enums;

namespace SafeDocAI.API.Services;

public class StatusDocumentoService
{
    public StatusDocumento CalcularStatus(DateTime dataValidade)
    {
        var hoje = DateTime.Today;

        if (dataValidade.Date < hoje)
            return StatusDocumento.Vencido;

        if (dataValidade.Date <= hoje.AddDays(30))
            return StatusDocumento.Vencendo;

        return StatusDocumento.EmDia;
    }
}