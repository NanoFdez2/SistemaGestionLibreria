using SistemaGestionLibreria.Services.DTO.DetallePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Pack
{
    public class PackDetailDto
    {
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }

        public int Stock { get; set; }
        public bool Activo { get; set; }
        public int CantidadLibros { get; set; }
        public List<DetallePackDto> Detalles { get; set; } = new();
    }
}
