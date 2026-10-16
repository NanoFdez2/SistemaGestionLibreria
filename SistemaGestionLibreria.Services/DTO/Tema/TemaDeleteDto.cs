using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.Tema
{
    public class TemaDeleteDto
    {
        public int TemaId { get; set; }
        public byte[] RowVersion { get; set; } = null!;

    }
}
