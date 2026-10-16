using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Pack
{
    public class PackListDto
    {
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = null!;
        public int Precio { get; set; }
        public int CantidadLibros { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }

    }
}
