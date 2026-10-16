using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Editorial
{
    public class EditorialDeleteDto
    {
        public int EditorialId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
