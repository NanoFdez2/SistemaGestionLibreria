using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Autor
{
    public class AutorUpdateDto
    {
        public int AutorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaDeNacimiento { get; set; }
        public string Nacionalidad { get; set; } = null!;
        public bool Activo { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
