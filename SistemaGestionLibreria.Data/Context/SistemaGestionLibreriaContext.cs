using Microsoft.EntityFrameworkCore;
using SistemaGestionLibreria.Entities;

namespace SistemaGestionLibreria.Data.Context
{
    public class SistemaGestionLibreriaContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<DetallePack> DetallesPack { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NANOFERNÁNDEZ;Initial Catalog=SistemaGestionLibreria;Integrated Security=True;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaGestionLibreriaContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .HasKey(p => p.Id);
        }
    }
}
