using SistemaGestionLibreria.Entities.Interfaces;

namespace SistemaGestionLibreria.Data.Interfaces
{
    public interface IRepositorioConcurrente<T> : IRepositorioGenerico<T> where T : class, IConcurrencyEntity
    {
        void Borrar(int id, byte[] rowVersion);
        void Editar(T entidad, int id, byte[] rowVersion);
    }
}
