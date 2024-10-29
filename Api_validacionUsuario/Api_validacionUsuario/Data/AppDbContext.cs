namespace Api_validacionUsuario.Data
{
    using Microsoft.EntityFrameworkCore;
    using Api_validacionUsuario.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(c => c.UsuarioID);
        }
    }

}
