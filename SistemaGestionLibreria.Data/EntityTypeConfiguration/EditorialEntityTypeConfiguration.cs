using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionLibreria.Entities;

namespace SistemaGestionLibreria.Data.EntityTypeConfiguration
{
    public class EditorialEntityTypeConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.HasKey(e => e.EditorialId);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PaisDeOrigen)
                .HasMaxLength(50);

            builder.Property(e => e.RowVersion).IsRowVersion();

            builder.Property(e => e.Activo).IsRequired();

            builder.HasMany(e => e.Libros)
                .WithOne(l => l.Editorial)
                .HasForeignKey(l => l.EditorialId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
