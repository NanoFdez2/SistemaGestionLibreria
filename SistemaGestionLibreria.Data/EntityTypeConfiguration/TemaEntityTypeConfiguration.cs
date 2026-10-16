using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionLibreria.Entities;

namespace SistemaGestionLibreria.Data.EntityTypeConfiguration
{
    public class TemaEntityTypeConfiguration : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.HasKey(t => t.TemaId);

            builder.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Descripcion)
                .HasMaxLength(250);

            builder.Property(t => t.RowVersion).IsRowVersion();

            builder.HasMany(t => t.Libros)
                .WithMany(l => l.Temas);
        }
    }
}
