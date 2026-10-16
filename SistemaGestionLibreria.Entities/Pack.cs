using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SistemaGestionLibreria.Entities.Interfaces;

namespace SistemaGestionLibreria.Entities
{
    public class Pack : Producto, IConcurrencyEntity
    {
        public decimal CantidadLibros { get; set; }
        public List<DetallePack> Detalles { get; set; } = new();
        public int Stock { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        public Pack()
        {

        }
        public Pack(string titulo, string descripcion, decimal cantidadLibros) : base(titulo, descripcion, true)
        {
            CantidadLibros = cantidadLibros;
        }

        public decimal CalcularSubTotal()
        {
            return Detalles.Sum(x => x.Libro.Precio * x.Cantidad);
        }

        public decimal Descuento()
        {
            // Descuento basado en la cantidad TOTAL de libros
            decimal cantidadTotal = Detalles.Sum(x => x.Cantidad);
            if (cantidadTotal >= 2 && cantidadTotal < 3)
                return 0.05m;

            if (cantidadTotal >= 3 && cantidadTotal < 4)
                return 0.10m;

            if (cantidadTotal >= 4 && cantidadTotal < 5)
                return 0.15m;

            if (cantidadTotal >= 5)
                return 0.20m;

            return 0;
        }

        public decimal CalcularPrecio()
        {
            decimal subtotal = CalcularSubTotal();
            decimal descuento = Descuento();
            return subtotal - (subtotal * descuento);
        }

        public override string MostrarDatos()
        {
            return $"{Titulo} - ${CalcularPrecio()} - {CantidadLibros} libros";
        }
    }
}

