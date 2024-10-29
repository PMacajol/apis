using Microsoft.EntityFrameworkCore;
using Api_NotaCredito.Models; // Espacio de nombres donde tienes tus modelos

namespace Api_NotaCredito.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Agregar DbSet para cada entidad que quieras mapear a una tabla
        public DbSet<NotaCredito> NotaCreditos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales de tus entidades (si es necesario)
        }
    }
}
