using Microsoft.EntityFrameworkCore;
using Api_EntregaPaquete.Models;

namespace Api_EntregaPaquete.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EntregaPaquete> EntregaPaquetes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntregaPaquete>().ToTable("EntregaPaquete");
        }
    }
}
