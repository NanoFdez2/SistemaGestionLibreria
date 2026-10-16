using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Data.EntityTypeConfiguration
{
    public class LibroEntityTypeConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            //builder.HasKey(l => l.Id);

            builder.Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.Descripcion)
                .HasMaxLength(250);

            builder.Property(l => l.ISBN)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(l => l.Precio)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(l => l.Stock)
                .IsRequired();

            builder.Property(l => l.AnioPublicacion)
                .IsRequired();

            builder.HasOne(l => l.Editorial)
                .WithMany(e => e.Libros)
                .HasForeignKey(l => l.EditorialId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a muchos con Autores
            builder.HasMany(l => l.Autores)
                .WithMany(a => a.Libros)
                .UsingEntity("LibroAutores");

            // Relación muchos a muchos con Temas
            builder.HasMany(l => l.Temas)
                .WithMany(t => t.Libros)
                .UsingEntity("LibroTemas");
        }
    }
}

