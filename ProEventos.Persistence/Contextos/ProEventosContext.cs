using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }

        public DbSet<Evento> tbeventos { get; set; }
        public DbSet<Lote> tblotes { get; set; }
        public DbSet<Palestrante> tbpalestrantes { get; set; }
        public DbSet<PalestranteEvento> tbpalestrantesEventos { get; set; }
        public DbSet<RedeSocial> tbredesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            modelBuilder.Entity<Evento>()
                 .HasMany(e => e.RedesSociais)
                 .WithOne(rs => rs.Evento)
                 .HasForeignKey(rs => rs.EventoId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                  .HasMany(e => e.RedesSociais)
                  .WithOne(rs => rs.Palestrante)
                  .HasForeignKey(rs => rs.PalestranteId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}