using Microsoft.EntityFrameworkCore;
using Api_Producto.Models;

namespace Api_Producto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí indicamos a Entity Framework que la tabla ya existe
            modelBuilder.Entity<Producto>().ToTable("Producto"); // Asegúrate que el nombre de la tabla coincida exactamente

            // Configurar clave primaria si es necesario
            modelBuilder.Entity<Producto>().HasKey(p => p.CodigoProducto);
        }
    }
}
