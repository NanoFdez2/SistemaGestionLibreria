using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionLibreria.Entities;

namespace SistemaGestionLibreria.Data.EntityTypeConfiguration
{
    public class ProductoEntityTypeConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Descripcion)
                .HasMaxLength(250);

            builder.Property(p => p.Activo)
                .IsRequired();

            builder.HasDiscriminator<string>("Discriminator")
                .HasValue<Producto>("Producto")
                .HasValue<Libro>("Libro")
                .HasValue<Pack>("Pack");
        }
    }
}
