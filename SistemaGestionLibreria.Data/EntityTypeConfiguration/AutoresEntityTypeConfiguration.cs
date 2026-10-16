using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionLibreria.Entities;

namespace SistemaGestionLibreria.Data.EntityTypeConfiguration
{
    public class AutoresEntityTypeConfiguration : IEntityTypeConfiguration<Autores>
    {
        public void Configure(EntityTypeBuilder<Autores> builder)
        {
            builder.HasKey(a => a.AutorId);
            builder.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Apellido).IsRequired().HasMaxLength(100);
            builder.Property(a => a.FechaDeNacimiento).IsRequired();
            builder.Property(a => a.Nacionalidad).IsRequired().HasMaxLength(50);
            builder.Property(a => a.RowVersion).IsRowVersion();
            builder.Property(a => a.Activo).HasDefaultValue(true);
        }
    }
}
