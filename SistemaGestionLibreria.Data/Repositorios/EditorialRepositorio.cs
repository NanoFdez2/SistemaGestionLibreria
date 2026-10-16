using SistemaGestionLibreria.Data.Context;
using SistemaGestionLibreria.Data.Interfaces;
using SistemaGestionLibreria.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SistemaGestionLibreria.Data.Repositorios
{
    public class EditorialRepositorio : RepositorioConcurrente<Editorial>, IEditorialRepositorio
    {
        public EditorialRepositorio(SistemaGestionLibreriaContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Editorial editorial)
        {
            return _context.Libros.Any(l => l.EditorialId == editorial.EditorialId);
        }

        public bool Existe(Editorial editorial)
        {
            return _context.Editoriales
                .Any(e => e.Nombre == editorial.Nombre &&
                e.EditorialId != editorial.EditorialId);
        }

        public double ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Editorial, bool>> filtrarPor = null)
        {
            var editorialEnDb = ObtenerPorId(seleccionadoId);
            if (editorialEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.Nombre, editorialEnDb.Nombre) <= 0);
        }

        public override List<Editorial> ObtenerTodos()
        {
            return _context.Editoriales
                .Include(e => e.Libros)
                .ToList();
        }
    }
}
