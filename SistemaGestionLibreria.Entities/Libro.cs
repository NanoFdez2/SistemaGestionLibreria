namespace SistemaGestionLibreria.Entities
{
    public class Libro : Producto
    {
        private int _stock;
        private decimal _precio;
        private int _anioPublicacion;

        public string ISBN { get; set; }
        
        public decimal Precio {
            get => _precio;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El precio no puede ser negativo.");
                }

                _precio = value;
            }
        }

        public int AnioPublicacion
        {
            get => _anioPublicacion;
            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "El año de publicación no puede ser negativo ni mayor al año actual.");
                }

                _anioPublicacion = value;
            }
        } 
        

        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El stock no puede ser negativo.");
                }

                _stock = value;
            }
        }


        public int? EditorialId { get; set; }
        public Editorial Editorial { get; set; }

        public List<Autores> Autores { get; set; } = new();

        public List<Tema> Temas { get; set; } = new();

        public List<DetallePack> DetallesPack { get; set; } = new();
        public Libro()
        {
            Autores = new();
            Temas = new();
            DetallesPack = new();
        }

        public Libro(string titulo, string descripcion, string isbn, decimal precio, int anioPublicacion, int stock) 
            : base (titulo, descripcion, true)
        {
            Titulo = titulo;
            Descripcion = descripcion;

            ISBN = isbn;
            Precio = precio;
            AnioPublicacion = anioPublicacion;
            Stock = stock;
        }

        public override string MostrarDatos()
        {
            return $"Libro: {Titulo}, ISBN: {ISBN}, Precio: {Precio:C2}, " +
                $"Año de Publicación: {AnioPublicacion}, Stock: {Stock}, Editorial: {Editorial?.Nombre}";
        }
    }
}
