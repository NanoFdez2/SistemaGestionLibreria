using SistemaGestionLibreria.Data.Context;
using SistemaGestionLibreria.Data.Interfaces;
using SistemaGestionLibreria.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SistemaGestionLibreria.Data.Repositorios
{
    public class TemaRepositorio : RepositorioConcurrente<Tema>, ITemaRepositorio
    {
        public TemaRepositorio(SistemaGestionLibreriaContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Tema tema)
        {
            return _context.Libros.Any(l => l.Temas.Any(t => t.TemaId == tema.TemaId));
        }

        public bool Existe(Tema tema)
        {
            return _context.Temas
                .Any(t => t.Nombre == tema.Nombre &&
                t.TemaId != tema.TemaId);
        }

        public double ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Tema, bool>>? filtrarPor = null)
        {
            var temaEnDb = ObtenerPorId(seleccionadoId);
            if (temaEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(tb => string.Compare(tb.Nombre, temaEnDb.Nombre) <= 0);
        }

        public override List<Tema> ObtenerTodos()
        {
            return _context.Temas
                .Include(t => t.Libros)
                .ToList();
        }
    }
}
