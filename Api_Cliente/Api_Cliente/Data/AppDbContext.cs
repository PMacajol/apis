namespace Api_Cliente.Data
{
    using Api_Cliente.Models;
    using Microsoft.EntityFrameworkCore;
    using Api_Cliente.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.CodigoCliente);
        }
    }

}
