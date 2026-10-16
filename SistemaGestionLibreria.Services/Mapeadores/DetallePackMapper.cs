using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.DTO.DetallePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Mapeadores
{
    public static class DetallePackMapper
    {
        public static DetallePackDto ToDto(this DetallePack detalle)
        {
            return new DetallePackDto
            {
                LibroId = detalle.LibroId,
                Titulo = detalle.Libro.Titulo,
                Precio = detalle.Libro.Precio,
                CantidadLibro = detalle.Cantidad 
            };
        }

    }
}
