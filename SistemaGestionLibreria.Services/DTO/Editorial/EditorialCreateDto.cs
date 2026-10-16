using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Editorial
{
    public class EditorialCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string PaisDeOrigen { get; set; }
        public bool Activo { get; set; }
    }
}
