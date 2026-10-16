using SistemaGestionLibreria.Entities;

namespace SistemaGestionLibreria.Data.Interfaces
{
    public interface IAutoresRepositorio : IRepositorioGenerico<Autores>
    {
        bool Existe(Autores autor);
        bool EstaRelacionado(Autores autor);
    }
}
