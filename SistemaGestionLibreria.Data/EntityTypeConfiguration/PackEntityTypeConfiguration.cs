using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionLibreria.Entities;

namespace SistemaGestionLibreria.Data.EntityTypeConfiguration
{
    public class PackEntityTypeConfiguration : IEntityTypeConfiguration<Pack>
    {
        public void Configure(EntityTypeBuilder<Pack> builder)
        {
            //builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Descripcion)
                .HasMaxLength(250);

            builder.Property(p => p.Activo)
                .IsRequired();

            builder.Property(p => p.CantidadLibros)
                .HasPrecision(18, 2);

            builder.Property(p => p.RowVersion)
                .IsRowVersion();

            // Relación uno a muchos: Pack -> DetallesPack
            builder.HasMany(p => p.Detalles)
                .WithOne(d => d.Pack)
                .HasForeignKey(d => d.PackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
