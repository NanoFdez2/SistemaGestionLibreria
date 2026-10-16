namespace SistemaGestionLibreria.Entities
{
    public abstract class Producto
    {
        private string _titulo = null!;
        private string? _descripcion;
        protected Producto()
        {

        }
        protected Producto(string titulo, string descripcion, bool activo)
        {

            Titulo = titulo;
            Descripcion = descripcion;
            Activo = activo;
        }

        public int Id { get; set; }
        public string Titulo
        {
            get => _titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El título del producto no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 100)
                {
                    throw new ArgumentException("El título del producto no puede superar los 100 caracteres.", nameof(value));
                }

                _titulo = value.Trim();
            }
        }
        public string Descripcion
        {
            get => _descripcion;
            set
            {
                if (value != null && value.Trim().Length > 250)
                {
                    throw new ArgumentException("La descripción no puede superar los 250 caracteres.", nameof(value));
                }

                _descripcion = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            }
        }
        public bool Activo { get; set; }

        public abstract string MostrarDatos();
    }
}
