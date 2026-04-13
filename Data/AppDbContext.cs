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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Unidade>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Documento>()
            .HasKey(d => d.Id);

        modelBuilder.Entity<Documento>()
            .HasOne(d => d.Unidade)
            .WithMany(u => u.Documentos)
            .HasForeignKey(d => d.UnidadeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Unidade>()
            .Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Entity<Unidade>()
            .Property(u => u.Cnpj)
            .IsRequired()
            .HasMaxLength(18);

        modelBuilder.Entity<Unidade>()
            .Property(u => u.Cidade)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Unidade>()
            .Property(u => u.Estado)
            .IsRequired()
            .HasMaxLength(2);

        modelBuilder.Entity<Documento>()
            .Property(d => d.Nome)
            .IsRequired()
            .HasMaxLength(150);
    }
}