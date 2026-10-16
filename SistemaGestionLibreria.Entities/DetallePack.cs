using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Entities
{
    /// <summary>
    /// Representa la relación entre un Pack y los Libros que lo componen.
    /// </summary>
    public class DetallePack
    {
        public int DetallePackId { get; set; }

        public int PackId { get; set; }
        public Pack Pack { get; set; } = null!;

        public int LibroId { get; set; }
        public Libro Libro { get; set; } = null!;

        public int Cantidad { get; set; } = 1; // Cantidad de este libro en el pack

        /// <summary>
        /// Constructor vacío para EF Core
        /// </summary>
        public DetallePack()
        {
        }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        public DetallePack(Libro libro)
        {
            if (libro == null)
                throw new ArgumentNullException(nameof(libro));

            Libro = libro;
            LibroId = libro.Id;
        }
    }
}
