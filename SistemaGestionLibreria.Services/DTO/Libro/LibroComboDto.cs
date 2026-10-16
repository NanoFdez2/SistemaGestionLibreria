using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Libro
{
    public class LibroComboDto
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; } = null!;
        public string NombreLibro => Titulo; // Alias para compatibilidad con bindings
        public decimal Precio { get; set; }
        public string ISBN { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public bool Activo { get; set; }
        public int Stock { get; set; }
    }
}
