using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Editorial;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Interfaces
{
    public interface IEditorialServicio
    {
        Result<List<EditorialListDto>> ObtenerTodos();
        Result<EditorialListDto> ObtenerPorId(int id);
        Result<EditorialUpdateDto> ObtenerParaEditar(int id);
        Result<EditorialDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(EditorialCreateDto editorialDto);
        Result Editar(EditorialUpdateDto editorialDto);
        Result Borrar(EditorialDeleteDto editorialDto);
        Result<List<EditorialListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<EditorialListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtroActivo = null, string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null);
    }
}
