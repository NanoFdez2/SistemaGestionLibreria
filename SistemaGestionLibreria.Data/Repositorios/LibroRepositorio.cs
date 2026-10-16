using SistemaGestionLibreria.Data.Context;
using SistemaGestionLibreria.Data.Interfaces;
using SistemaGestionLibreria.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SistemaGestionLibreria.Data.Repositorios
{
    public class LibroRepositorio : RepositorioGenerico<Libro>, ILibroRepositorio
    {
        public LibroRepositorio(SistemaGestionLibreriaContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Libro libro)
        {
            return _context.DetallesPack.Any(d => d.LibroId == libro.Id);
        }

        public bool Existe(Libro libro)
        {
            return _context.Libros
                .Any(l => l.ISBN == libro.ISBN &&
                l.Id != libro.Id);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Libro, bool>>? filtrarPor)
        {
            var libroEnDb = ObtenerPorId(seleccionadoId);
            if (libroEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.Titulo, libroEnDb.Titulo) <= 0);
        }

        public override List<Libro> ObtenerTodos()
        {
            return _context.Libros
                .Include(l => l.Editorial)
                .Include(l => l.Autores)
                .Include(l => l.Temas)
                .ToList();
        }
    }
}
