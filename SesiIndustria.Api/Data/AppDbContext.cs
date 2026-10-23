using Microsoft.EntityFrameworkCore;
using SesiIndustria.Api.Models;

namespace SesiIndustria.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Modulo> Modulos => Set<Modulo>();
    public DbSet<Aula> Aulas => Set<Aula>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.NomeCompleto).IsRequired().HasMaxLength(200);
            entity.Property(c => c.NomeBreve).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Categoria).IsRequired().HasMaxLength(80);
            entity.Property(c => c.Modalidade).IsRequired().HasMaxLength(80);
            entity.Property(c => c.Status).IsRequired().HasMaxLength(50);
            entity.Property(c => c.PublicoAlvo).HasMaxLength(300);
            entity.Property(c => c.Imagem).HasMaxLength(255);
            entity.Property(c => c.IconeCategoria).HasMaxLength(255);

            entity.HasMany(c => c.Modulos)
                  .WithOne(m => m.Curso)
                  .HasForeignKey(m => m.CursoId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Titulo).IsRequired().HasMaxLength(150);

            entity.HasMany(m => m.Aulas)
                  .WithOne(a => a.Modulo)
                  .HasForeignKey(a => a.ModuloId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Titulo).IsRequired().HasMaxLength(150);
            entity.Property(a => a.Duracao).HasMaxLength(30);
        });
    }
}
