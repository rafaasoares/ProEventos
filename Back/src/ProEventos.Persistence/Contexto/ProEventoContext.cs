using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contexto
{
    public class ProEventoContext : DbContext
    {
        public ProEventoContext(DbContextOptions<ProEventoContext> options)
            : base(options) {}
        
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedeSocials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(x => new {x.EventoId, x.PalestranteId});

            // Para deletar em cascata
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedeSociais)
                .WithOne(rs=> rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(p => p.RedeSociais)
                .WithOne(rs=> rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}