using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionLibreria.Entities;

namespace SistemaGestionLibreria.Data.EntityTypeConfiguration
{
    public class DetallePackEntityTypeConfiguration : IEntityTypeConfiguration<DetallePack>
    {
        public void Configure(EntityTypeBuilder<DetallePack> builder)
        {
            builder.HasKey(d => d.DetallePackId);

            builder.HasIndex(d => new { d.PackId, d.LibroId })
                .IsUnique();

            builder.HasOne(d => d.Pack)
                .WithMany(p => p.Detalles)
                .HasForeignKey(d => d.PackId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Libro)
                .WithMany()
                .HasForeignKey(d => d.LibroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
