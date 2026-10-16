using SistemaGestionLibreria.Data.Context;
using SistemaGestionLibreria.Data.Interfaces;
using SistemaGestionLibreria.Data.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionLibreria.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaGestionLibreriaContext _context;
        public IPackRepositorio Packs { get; }
        public ILibroRepositorio Libros { get; }
        public IAutoresRepositorio Autores { get; }
        public ITemaRepositorio Temas { get; }
        public IEditorialRepositorio Editoriales { get; }

        public UnitOfWork(
            IPackRepositorio packRepositorio,
            ILibroRepositorio libroRepositorio,
            IAutoresRepositorio autoresRepositorio,
            ITemaRepositorio temaRepositorio,
            IEditorialRepositorio editorialRepositorio,
            SistemaGestionLibreriaContext context)
        {
            Packs = packRepositorio;
            Libros = libroRepositorio;
            Autores = autoresRepositorio;
            Temas = temaRepositorio;
            Editoriales = editorialRepositorio;
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            foreach (var item in _context.ChangeTracker.Entries())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.State = EntityState.Unchanged;
                        item.CurrentValues.SetValues(item.OriginalValues);
                        break;
                    case EntityState.Added:
                        item.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        item.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
