using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.DTO.Tema;

namespace SistemaGestionLibreria.Services.DTO.Libro
{
    public class LibroUpdateDto
    {
        public int ProductoId { get; set; }
        public string ISBN { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int AnioPublicacion { get; set; }
        public int Stock { get; set; }
        public int? EditorialId { get; set; }
        public List<Autores> AutoresId { get; set; } = null!;
        public List<Entities.Tema> TemasId { get; set; } = null!;
        public bool Activo { get; set; }
        public byte[] RowVersion { get; set; } = null!;

    }
}
