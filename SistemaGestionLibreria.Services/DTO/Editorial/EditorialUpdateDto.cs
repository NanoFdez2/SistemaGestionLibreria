using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Editorial
{
    public class EditorialUpdateDto
    {
        public int EditorialId { get; set; }
        public string Nombre { get; set; } = null!;
        public string PaisDeOrigen { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;
        public bool? Activo { get; set; }
    }
}
