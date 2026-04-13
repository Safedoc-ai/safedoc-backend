namespace SafeDocAI.API.DTOs;

public class DashboardDto
{
    public int TotalUnidades { get; set; }
    public int DocumentosEmDia { get; set; }
    public int DocumentosVencendo { get; set; }
    public int DocumentosVencidos { get; set; }
}