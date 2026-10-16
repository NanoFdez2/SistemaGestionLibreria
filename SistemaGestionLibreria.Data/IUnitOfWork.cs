using SistemaGestionLibreria.Data.Interfaces;

namespace SistemaGestionLibreria.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPackRepositorio Packs { get; }
        ILibroRepositorio Libros { get; }
        IAutoresRepositorio Autores { get; }
        ITemaRepositorio Temas { get; }
        IEditorialRepositorio Editoriales { get; }
        void Save();
        void RollBack();
    }
}
