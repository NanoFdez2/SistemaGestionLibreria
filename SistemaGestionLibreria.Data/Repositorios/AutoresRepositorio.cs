using SistemaGestionLibreria.Data.Context;
using SistemaGestionLibreria.Data.Interfaces;
using SistemaGestionLibreria.Entities;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionLibreria.Data.Repositorios
{
    public class AutoresRepositorio : RepositorioGenerico<Autores>, IAutoresRepositorio
    {
        public AutoresRepositorio(SistemaGestionLibreriaContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Autores autor)
        {
            return _context.Libros.Any(l => l.Autores.Any(a => a.AutorId == autor.AutorId));
        }

        public bool Existe(Autores autor)
        {
            return _context.Autores
                .Any(a => a.Nombre == autor.Nombre && 
                a.Apellido == autor.Apellido &&
                a.AutorId != autor.AutorId);
        }

        public override List<Autores> ObtenerTodos()
        {
            return _context.Autores
                .Include(a => a.Libros)
                .ToList();
        }
    }
}
