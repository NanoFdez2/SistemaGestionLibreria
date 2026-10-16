using SistemaGestionLibreria.Services.DTO.DetallePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Pack
{
    public class PackUpdateDto
    {
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }
        public int CantidadLibros { get; set; }
        public bool Activo { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public List<DetallePackDto> Detalles { get; set; } = new();

    }
}
