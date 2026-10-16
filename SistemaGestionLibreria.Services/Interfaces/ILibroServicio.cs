using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Libro;
using SistemaGestionLibreria.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Interfaces
{
    public interface ILibroServicio
    {
        Result<List<LibroListDto>> ObtenerTodos();
        Result<ResultadoPaginacionDto<LibroListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);

        Result<LibroListDto> ObtenerPorId(int id);
        Result<LibroUpdateDto> ObtenerParaEditar(int id);
        Result<int> Agregar(LibroCreateDto libroDto);
        Result Editar(LibroUpdateDto libroDto);
        Result Borrar(LibroDeleteDto libroDto);
        Result<LibroDeleteDto> ObtenerParaBorrar(int productoId);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
                    bool? filtroActivo = null);
        Result<List<LibroComboDto>> ObtenerDatosCombo(LibroDefault defaultLibro, bool activos);
    }
}
