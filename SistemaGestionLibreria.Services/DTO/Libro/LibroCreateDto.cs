using SistemaGestionLibreria.Entities;

namespace SistemaGestionLibreria.Services.DTO.Libro
{
    public class LibroCreateDto
    {
        public string ISBN { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int AnioPublicacion { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }

        public int? EditorialId { get; set; }
        public List<Autores> AutoresId { get; set; } = new();
        public List<SistemaGestionLibreria.Entities.Tema> TemasId { get; set; } = new();
    }
}
