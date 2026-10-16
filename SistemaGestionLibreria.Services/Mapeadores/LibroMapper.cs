using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.DTO.Libro;
using System;
using System.Collections.Generic;
using System.Text;
using static Azure.Core.HttpHeader;

namespace SistemaGestionLibreria.Services.Mapeadores
{
    public static class LibroMapper
    {
        public static LibroListDto ToListDto(this Libro libro)
        {
            return new LibroListDto
            {
                ProductoId = libro.Id,
                Titulo = libro.Titulo,
                Descripcion = libro.Descripcion,
                Autores = libro.Autores,
                Precio = libro.Precio,
                Stock = libro.Stock,
                ISBN = libro.ISBN,
                AnioPublicacion = libro.AnioPublicacion,
                EditorialId = libro.EditorialId,
                Temas = libro.Temas,
                Activo = libro.Activo
            };
        }

        public static Libro ToEntidad(this LibroCreateDto dto)
        {
            var libro = new Libro
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion ?? "",
                Precio = dto.Precio,
                Stock = dto.Stock,
                ISBN = dto.ISBN,
                AnioPublicacion = dto.AnioPublicacion,
                EditorialId = dto.EditorialId,
                Activo = dto.Activo,
                Autores = dto.AutoresId ?? new(),
                Temas = dto.TemasId ?? new()
            };

            return libro;
        }

        public static Libro ToEntidad(this LibroUpdateDto dto)
        {
            return new Libro
            {
                Id = dto.ProductoId,
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Autores = dto.AutoresId,
                Precio = dto.Precio,
                Stock = dto.Stock,
                ISBN = dto.ISBN,
                AnioPublicacion = dto.AnioPublicacion,
                EditorialId = dto.EditorialId,
                Temas = dto.TemasId,
                Activo = dto.Activo
            };
        }
        public static LibroUpdateDto ToUpdateDto(this Libro libro)
        {
            return new LibroUpdateDto
            {
                ProductoId = libro.Id,
                Titulo = libro.Titulo,
                AutoresId = libro.Autores,
                Precio = libro.Precio,
                Stock = libro.Stock,
                ISBN = libro.ISBN,
                AnioPublicacion = libro.AnioPublicacion,
                EditorialId = libro.EditorialId,
                TemasId = libro.Temas
            };
        }

        public static LibroDeleteDto ToDeleteDto(this Libro libro)
        {
            return new LibroDeleteDto
            {
                productoId = libro.Id
            };
        }

    }
}

//public class LibroCreateDto
//{   
//    public string ISBN { get; set; }
//    public string Titulo { get; set; }
//    public string Descripcion { get; set; }
//    public decimal Precio { get; set; }
//    public int AnioPublicacion { get; set; }
//    public int Stock { get; set; }
//    public int EditorialId { get; set; }
//    public List<Autores> Autores { get; set; }
//    public List<Tema> Temas { get; set; }
//}


