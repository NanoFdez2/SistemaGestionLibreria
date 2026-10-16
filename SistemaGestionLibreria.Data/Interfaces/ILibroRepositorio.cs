using SistemaGestionLibreria.Entities;
using System.Linq.Expressions;
using static Azure.Core.HttpHeader;

namespace SistemaGestionLibreria.Data.Interfaces
{
    public interface ILibroRepositorio : IRepositorioGenerico<Libro>
    {
        bool Existe(Libro libro);
        bool EstaRelacionado(Libro libro);
        int ObtenerPosicionRegistro(int seleccionadoId, Expression<Func<Libro, bool>>? filtrarPor);
    }
}
