using SistemaGestionLibreria.Entities;
using System.Linq.Expressions;

namespace SistemaGestionLibreria.Data.Interfaces
{
    public interface ITemaRepositorio : IRepositorioConcurrente<Tema>
    {
        bool Existe(Tema tema);
        bool EstaRelacionado(Tema tema);
        double ObtenerPosicionRegistro(int seleccionadoId,
            Expression<Func<Tema, bool>>? filtrarPor=null);
    }
}
