using Microsoft.EntityFrameworkCore;
using SafeDocAI.API.Models;

namespace SafeDocAI.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Documento> Documentos { get; set; }
    public DbSet<Unidade> Unidades { get; set; }
}