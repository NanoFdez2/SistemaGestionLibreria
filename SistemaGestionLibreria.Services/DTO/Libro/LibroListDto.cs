using SistemaGestionLibreria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Libro
{
    public class LibroListDto
    {
        public int ProductoId { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int AnioPublicacion { get; set; }
        public int Stock { get; set; }
        public int? EditorialId { get; set; }
        public List<Autores> Autores { get; set; } = null!;
        public List<Entities.Tema> Temas { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
