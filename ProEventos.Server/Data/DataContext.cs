using Microsoft.EntityFrameworkCore;
using ProEventos.Server.Models;

namespace ProEventos.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Eventos> Tbeventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eventos>()
                .HasKey(e => e.EventoId); 
        }
    }
}