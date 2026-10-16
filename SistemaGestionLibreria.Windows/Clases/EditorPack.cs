using SistemaGestionLibreria.Services.DTO.DetallePack;
using SistemaGestionLibreria.Services.DTO.Libro;
using SistemaGestionLibreria.Services.DTO.Pack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Windows.Clases
{
    public class EditorPack
    {
        private PackUpdateDto _packDto;
        public EditorPack(PackUpdateDto packDto)
        {
            _packDto = packDto;
        }
        public void AgregarBombon(LibroComboDto bombon, int cantidad)
        {
            if (bombon is null)
            {
                throw new ArgumentNullException(nameof(bombon), "" +
                    "El bombón no puede ser nullo");
            }
            if (cantidad <= 0) throw
                    new ArgumentOutOfRangeException("La cantidad no puede ser nula");
            var detalleEnCaja = _packDto.Detalles
                .FirstOrDefault(d => d.LibroId == bombon.LibroId);
            if (detalleEnCaja == null)
            {
                _packDto.Detalles.Add(new DetallePackDto
                {
                    LibroId = bombon.LibroId,
                    Titulo = bombon.Titulo,
                    Precio = bombon.Precio,
                    CantidadLibro = cantidad,

                });
                return;
            }
            detalleEnCaja.CantidadLibro += cantidad;
        }
        public (IReadOnlyCollection<DetallePackDto> Detalles,
            int Cantidad, decimal Precio, bool Activo) ObtenerResumen()
        {
            var detalles = _packDto.Detalles.AsReadOnly();
            var cantidad = _packDto.Detalles.Sum(d => d.CantidadLibro);
            var precio = Math.Ceiling(_packDto.Detalles.Sum(d => d.Subtotal) * 1.2m / 100) * 100;
            var activo = _packDto.Detalles.Count() > 1;
            return (detalles, cantidad, precio, activo);
        }

        public void AgregarLibro(LibroComboDto libro, int cantidad)
        {
            if (libro is null)
            {
                throw new ArgumentNullException(nameof(libro), "" +
                    "El libro no puede ser nulo");
            }
            if (cantidad <= 0) throw
                    new ArgumentOutOfRangeException("La cantidad no puede ser nula");

            // Validar que el libro esté activo
            if (!libro.Activo)
            {
                throw new InvalidOperationException("No se puede agregar un libro inactivo al pack.");
            }

            // Validar que el libro tenga stock disponible
            if (libro.Stock <= 0)
            {
                throw new InvalidOperationException("No se puede agregar un libro sin stock disponible al pack.");
            }

            var detalleEnCaja = _packDto.Detalles
                .FirstOrDefault(d => d.LibroId == libro.LibroId);
            if (detalleEnCaja != null)
            {
                throw new InvalidOperationException("El libro seleccionado ya se encuentra cargado.");
            }
            _packDto.Detalles.Add(new DetallePackDto
            {
                LibroId = libro.LibroId,
                Titulo = libro.Titulo,
                Precio = libro.Precio,
                CantidadLibro = cantidad,
            });
        }

        public void EliminarLibro(int libroId)
        {
            // Validar que el pack tenga al menos 2 libros antes de eliminar
            if (_packDto.Detalles.Count <= 2)
            {
                throw new InvalidOperationException("No se puede eliminar el libro. El pack debe contener al menos 2 libros.");
            }

            var detalleEnCaja = _packDto.Detalles
                .FirstOrDefault(d => d.LibroId == libroId);
            if (detalleEnCaja != null)
            {
                _packDto.Detalles.Remove(detalleEnCaja);
            }
        }
    }
}
