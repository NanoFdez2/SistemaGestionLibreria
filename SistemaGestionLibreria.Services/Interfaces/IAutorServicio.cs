using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Autor;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Interfaces
{
    public interface IAutorServicio
    {
        Result<List<AutorListDto>> ObtenerTodos();
        Result<ResultadoPaginacionDto<AutorListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);

        Result<AutorListDto> ObtenerPorId(int id);
        Result<AutorUpdateDto> ObtenerParaEditar(int id);
        Result<int> Agregar(AutorCreateDto autorDto);
        Result Editar(AutorUpdateDto autorDto);
        Result Borrar(int id);
    }
}
