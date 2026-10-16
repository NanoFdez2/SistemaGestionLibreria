using System;
using System.Collections.Generic;
using System.Text;
using SistemaGestionLibreria.Services.DTO.DetallePack;

namespace SistemaGestionLibreria.Services.DTO.Pack
{
    public class PackCreateDto
    {
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }
        public bool Activo { get; set; }
        public int CantidadLibros { get; set; }
        public List<DetallePackDto> Detalles { get; set; } = new();

    }
}
