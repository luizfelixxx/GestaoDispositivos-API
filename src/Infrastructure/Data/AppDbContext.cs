using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Dispositivo> Dispositivos { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da entidade Cliente
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Nome).IsRequired().HasMaxLength(150);
            entity.HasIndex(c => c.Email).IsUnique();
            entity.Property(c => c.Email).IsRequired().HasMaxLength(150);
            entity.Property(c => c.Telefone).HasMaxLength(20);
            entity.Property(c => c.Status).IsRequired();
        });
        
        // Configuração da entidade Dispositivo
        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(d => d.Id);
            entity.Property(d => d.Serial).IsRequired().HasMaxLength(50);
            entity.HasIndex(d => d.Serial).IsUnique();
            entity.Property(d => d.IMEI).IsRequired().HasMaxLength(50);
            entity.HasOne(d => d.Cliente)
                .WithMany(c => c.Dispositivos)
                .HasForeignKey(d => d.ClienteId);
        });
        
        // Configuração da entidade Evento
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Tipo).IsRequired();
            entity.Property(e => e.DataHora).IsRequired();
            entity.HasOne(e => e.Dispositivo)
                .WithMany()
                .HasForeignKey(e => e.DispositivoId);
        });
    }
}   
