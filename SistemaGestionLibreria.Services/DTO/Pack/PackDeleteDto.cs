using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Pack
{
    public class PackDeleteDto
    {
        public int ProductoId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
