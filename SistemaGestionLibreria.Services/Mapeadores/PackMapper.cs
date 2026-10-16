using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.DTO.Pack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaGestionLibreria.Services.Mapeadores
{
    public static class PackMapper
    {
        public static PackDetailDto ToDetailDto(this Pack pack)
        {
            return new PackDetailDto
            {
                ProductoId = pack.Id,
                Titulo = pack.Titulo,
                Descripcion = pack.Descripcion,
                Precio = pack.CalcularPrecio(),
                Stock = pack.Stock,
                Activo = pack.Activo,
                CantidadLibros = (int)pack.CantidadLibros,
                Detalles = pack.Detalles.Select(d => d.ToDto()).ToList(),
            };
        }
        public static PackListDto ToListDto(this Pack pack)
        {
            return new PackListDto
            {
                ProductoId = pack.Id,
                Titulo = pack.Titulo,
                Precio = (int)pack.CalcularPrecio(),
                CantidadLibros = (int)pack.Detalles.Sum(d => d.Cantidad),
                Stock = pack.Stock,
                Activo = pack.Activo
            };
        }

        public static Pack ToEntidad(this PackCreateDto dto)
        {
            var pack = new Pack
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Stock = dto.Stock,
                Activo = dto.Activo,
                CantidadLibros = dto.CantidadLibros
            };

            // Agregar los detalles (libros)
            if (dto.Detalles != null && dto.Detalles.Any())
            {
                foreach (var detalle in dto.Detalles)
                {
                    pack.Detalles.Add(new DetallePack
                    {
                        LibroId = detalle.LibroId,
                        Cantidad = detalle.CantidadLibro,
                        Libro = null! 
                    });
                }
            }

            return pack;
        }
        public static PackUpdateDto ToUpdateDto(this Pack pack)
        {
            return new PackUpdateDto
            {
                ProductoId = pack.Id,
                Titulo = pack.Titulo,
                Descripcion = pack.Descripcion,
                Stock = pack.Stock,
                Activo = pack.Activo,
                RowVersion = pack.RowVersion,
                Detalles = pack.Detalles.Select(d => d.ToDto()).ToList(),
            };
        }
        public static PackDeleteDto ToDeleteDto(this Pack pack)
        {
            return new PackDeleteDto
            {
                ProductoId = pack.Id
            };
        }
    }
}
