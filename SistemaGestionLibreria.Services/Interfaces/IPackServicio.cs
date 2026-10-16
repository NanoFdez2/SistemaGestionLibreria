using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Pack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Interfaces
{
    public interface IPackServicio
    {
        Result<List<PackListDto>> ObtenerTodos();
        Result<ResultadoPaginacionDto<PackListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null, int? temaId = null);

        Result<PackListDto> ObtenerPorId(int id);
        Result<PackUpdateDto> ObtenerParaEditar(int id);
        Result<int> Agregar(PackCreateDto PackDto);
        Result Editar(PackUpdateDto PackDto);
        Result Borrar(PackDeleteDto PackDto);
        Result<PackDeleteDto> ObtenerParaBorrar(int productoId);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
                    bool? filtroActivo = null, string? textBuscar = null);
        Result<PackDetailDto> ObtenerPackConDetalle(int packId);
    }
}
