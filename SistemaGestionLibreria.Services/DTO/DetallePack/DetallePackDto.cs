using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SistemaGestionLibreria.Services.DTO.DetallePack
{
    public class DetallePackDto
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; } = null!;
        [Browsable(false)]
        public decimal Precio { get; set; }
        public int CantidadLibro { get; set; }
        [Browsable(false)]
        public decimal Subtotal => Precio * CantidadLibro;
    }
}
