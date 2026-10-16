using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Libro
{
    public class LibroDeleteDto
    {
        public int productoId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
