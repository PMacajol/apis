using Microsoft.EntityFrameworkCore;
using Api_Venta.Models;

namespace Api_Venta.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venta>()
                .HasKey(v => v.CodigoVenta);
        }

    }
}
