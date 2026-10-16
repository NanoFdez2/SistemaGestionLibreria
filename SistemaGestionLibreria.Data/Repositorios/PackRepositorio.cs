using SistemaGestionLibreria.Data.Context;
using SistemaGestionLibreria.Data.Interfaces;
using SistemaGestionLibreria.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SistemaGestionLibreria.Data.Repositorios
{
    public class PackRepositorio : RepositorioConcurrente<Pack>, IPackRepositorio
    {
        public PackRepositorio(SistemaGestionLibreriaContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Pack pack)
        {
            return false;
        }

        public bool Existe(Pack pack)
        {
            return _context.Packs
                .Any(p => p.Titulo == pack.Titulo &&
                p.Id != pack.Id);
        }

        public override List<Pack> ObtenerTodos()
        {
            return _context.Packs
                .Include(p => p.Detalles)
                .ThenInclude(d => d.Libro)
                .ToList();
        }

        public override Pack? ObtenerPorId(int id)
        {
            return _context.Packs
                .Include(p => p.Detalles)
                .ThenInclude(d => d.Libro)
                .FirstOrDefault(p => p.Id == id);
        }

        public int ObtenerPosicionRegistro(int seleccionadoId, 
            Expression<Func<Pack, bool>>? filtrarPor = null)
        {
            var packEnDb = ObtenerPorId(seleccionadoId);
            if (packEnDb is null) return 0;
            var query = Query();
            if (filtrarPor is not null)
            {
                query = query.Where(filtrarPor);
            }
            return query
                .Count(p => string.Compare(p.Titulo, packEnDb.Titulo) <= 0);
        }
    }
}
