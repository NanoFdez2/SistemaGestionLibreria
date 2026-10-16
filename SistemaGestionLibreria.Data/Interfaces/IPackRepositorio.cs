using SistemaGestionLibreria.Entities;
using System.Linq.Expressions;

namespace SistemaGestionLibreria.Data.Interfaces
{
    public interface IPackRepositorio : IRepositorioConcurrente<Pack>
    {
        bool Existe(Pack pack);
        bool EstaRelacionado(Pack pack);
        int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Pack, bool>>? filtrarPor);
    }
}
