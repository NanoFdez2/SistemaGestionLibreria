using System;
using System.Collections.Generic;
using System.Text;
using SistemaGestionLibreria.Entities.Interfaces;

namespace SistemaGestionLibreria.Entities
{
    public class Autores : IConcurrencyEntity
    {
        public int AutorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaDeNacimiento { get; set; }
        public string Nacionalidad { get; set; } = null!;
        public List<Libro> Libros { get; set; } = new List<Libro>();
        public bool Activo { get; set; } = true;
        public byte[] RowVersion { get; set; } = null!;
    }
}
