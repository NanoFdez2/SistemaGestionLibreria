using System;
using System.Collections.Generic;
using System.Text;
using SistemaGestionLibreria.Entities.Interfaces;

namespace SistemaGestionLibreria.Entities
{
    public class Tema : IConcurrencyEntity
    {
        public int TemaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public List<Libro> Libros { get; set; } = new();
        public byte[] RowVersion { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
