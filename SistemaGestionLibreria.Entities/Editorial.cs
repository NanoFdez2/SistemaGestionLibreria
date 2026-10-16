using SistemaGestionLibreria.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Entities
{
    public class Editorial : IConcurrencyEntity
    {
        public int EditorialId { get; set; }
        public string Nombre { get; set; } = null!;
        public string PaisDeOrigen { get; set; }
        public List <Libro> Libros { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
