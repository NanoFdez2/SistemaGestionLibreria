using SistemaGestionLibreria.Entities.Enums;
using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Tema;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Interfaces
{
    public interface ITemaServicio
    {
        Result<List<TemaListDto>> ObtenerTodos();
        Result<TemaListDto> ObtenerPorId(int id);
        Result<TemaUpdateDto> ObtenerParaEditar(int id);
        Result<TemaDeleteDto> ObtenerParaBorrar(int id);

        Result<int> Agregar(TemaCreateDto temaDto);
        Result Editar(TemaUpdateDto temaDto);
        Result Borrar(TemaDeleteDto temaDto);
        Result<List<TemaListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<TemaListDto>> ObtenerPagina(int pagina,
            int cantidad, string campoOrdenar, bool esAscendente,
            bool? filtroActivo = null, string? textoBuscar = null);
        Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina,
            bool? filtroActivo = null, string? textoBuscar = null);
        Result<List<TemaListDto>> ObtenerDatosCombo(TemaDefault temaDefault);
    }
}
