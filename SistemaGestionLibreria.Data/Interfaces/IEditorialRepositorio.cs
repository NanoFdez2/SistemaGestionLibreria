using SistemaGestionLibreria.Entities;
using System.Linq.Expressions;

namespace SistemaGestionLibreria.Data.Interfaces
{
    public interface IEditorialRepositorio : IRepositorioConcurrente<Editorial>
    {
        bool Existe(Editorial editorial);
        bool EstaRelacionado(Editorial editorial);
        double ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Editorial, bool>> filtrarPor = null);
    }
}
