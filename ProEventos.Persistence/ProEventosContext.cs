using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
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
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
        }
    }
}