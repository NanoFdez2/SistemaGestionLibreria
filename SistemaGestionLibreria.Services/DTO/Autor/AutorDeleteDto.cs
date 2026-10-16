using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Autor
{
    public class AutorDeleteDto
    {
        public int AutorId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
