using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SistemaGestionLibreria.Data;
using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Pack;
using SistemaGestionLibreria.Services.Interfaces;
using SistemaGestionLibreria.Services.Mapeadores;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SistemaGestionLibreria.Services.Servicios
{
    public class PackServicio : IPackServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<PackCreateDto> _createValidator;
        private readonly IValidator<PackUpdateDto> _updateValidator;
        public PackServicio(IUnitOfWork unitOfWork, IValidator<PackCreateDto> createValidator, IValidator<PackUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        public Result<int> Agregar(PackCreateDto PackDto)
        {
            var validationResult = _createValidator.Validate(PackDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<int>.Failure(errors);
            }

            var Pack = PackMapper.ToEntidad(PackDto);

            if (_unitOfWork.Packs.Existe(Pack))
            {
                return Result<int>.Failure("El Pack ya existe.");
            }

            try
            {
                _unitOfWork.Packs.Agregar(Pack);
                _unitOfWork.Save();
                return Result<int>.Success(Pack.Id);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar el Pack: {ex.Message}");
            }
        }

        public Result Borrar(PackDeleteDto PackDto)
        {
            var caja = _unitOfWork.Packs.ObtenerPorId(PackDto.ProductoId);
            if (caja == null)
            {
                return Result.Failure("Pack no encontrado.");
            }

            try
            {
                _unitOfWork.Packs.Borrar(caja.Id);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar el Pack: {ex.Message}");
            }
        }

        public Result Editar(PackUpdateDto PackDto)
        {
            var validationResult = _updateValidator.Validate(PackDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Failure(errors);
            }


            var caja = _unitOfWork.Packs.ObtenerPorId(PackDto.ProductoId);
            if (caja == null)
            {
                return Result.Failure("Pack no encontrado.");
            }

            caja.Titulo = PackDto.Titulo;
            caja.Descripcion = PackDto.Descripcion;
            caja.Stock = PackDto.Stock;
            caja.Activo = PackDto.Activo;
            caja.CantidadLibros = PackDto.CantidadLibros;
            caja.RowVersion = PackDto.RowVersion;

            // Reemplazar los detalles (libros)
            caja.Detalles.Clear();
            if (PackDto.Detalles != null && PackDto.Detalles.Any())
            {
                foreach (var detalle in PackDto.Detalles)
                {
                    caja.Detalles.Add(new DetallePack
                    {
                        LibroId = detalle.LibroId,
                        Cantidad = detalle.CantidadLibro,
                        Libro = null! 
                    });
                }
            }

            if (_unitOfWork.Packs.Existe(caja))
            {
                return Result.Failure("Ya existe otro Pack registrado con los mismos datos.");
            }

            try
            {
                _unitOfWork.Packs.Editar(caja, caja.Id, PackDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el Pack: {ex.Message}");
            }
        }

        public Result<PackDetailDto> ObtenerPackConDetalle(int packId)
        {
            try
            {
                Pack? caja = _unitOfWork.Packs.ObtenerPorId(packId);
                if (caja is null)
                {
                    return Result<PackDetailDto>.Failure($"No se encontró" +
                        $" el pack con ID {packId}");
                }
                PackDetailDto packDto = caja.ToDetailDto();
                return Result<PackDetailDto>.Success(packDto);
            }
            catch (Exception ex)
            {

                return Result<PackDetailDto>.Failure($"Se produjo un error " +
                    $"al intentar obtener el pack {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<PackListDto>> ObtenerPaginado(int paginaActual, int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo, string? textoBuscar = null, int? temaId = null)
        {
            try
            {
                Expression<Func<Pack, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Titulo.Contains(textoBuscar)) &&
                        (temaId == null || b.Detalles.Any(d => d.Libro.Temas.Any(t => t.TemaId == temaId)));
                Func<IQueryable<Pack>, IOrderedQueryable<Pack>>? ordenarPor = campoOrdenar switch
                {
                    "ProductoId" => q => esAscendente ? q.OrderBy(c => c.Id) : q.OrderByDescending(c => c.Id),
                    "Nombre" => q => esAscendente ? q.OrderBy(c => c.Titulo) : q.OrderByDescending(c => c.Titulo),
                    _ => q => esAscendente ? q.OrderBy(c => c.Titulo) : q.OrderByDescending(c => c.Titulo),
                };
                Func<IQueryable<Pack>, IQueryable<Pack>> incluir = q => q.Include(c => c.Detalles)
                                .ThenInclude(d => d.Libro)
                                .ThenInclude(l => l.Temas);
                var resultado = _unitOfWork.Packs.ObtenerPagina(paginaActual, cantidadPorPagina, ordenarPor, filtro, incluir);
                var listaDto = resultado.lista
                    .Select(b => b.ToListDto()).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<PackListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidadPorPagina,
                    PaginaActual = paginaActual
                };

                return Result<ResultadoPaginacionDto<PackListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<PackListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina, bool? filtroActivo = null, string? textBuscar = null)
        {
            try
            {
                Expression<Func<Pack, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textBuscar) || b.Titulo.Contains(textBuscar));

                var posicion = _unitOfWork.Packs.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<PackDeleteDto> ObtenerParaBorrar(int productoId)
        {
            var pack = _unitOfWork.Packs.ObtenerPorId(productoId);
            if (pack != null)
            {
                var PackDto = PackMapper.ToDeleteDto(pack);
                return Result<PackDeleteDto>.Success(PackDto);
            }

            return Result<PackDeleteDto>.Failure("Error al intentar obtener el pack");
        }

        public Result<PackUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var pack = _unitOfWork.Packs.ObtenerPorId(id);
                if (pack == null)
                {
                    return Result<PackUpdateDto>.Failure("Pack no encontrado.");
                }

                var packDto = pack.ToUpdateDto();
                return Result<PackUpdateDto>.Success(packDto);
            }
            catch (Exception ex)
            {
                return Result<PackUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<PackListDto> ObtenerPorId(int id)
        {
            try
            {
                var caja = _unitOfWork.Packs.ObtenerPorId(id);
                if (caja == null)
                {
                    return Result<PackListDto>.Failure("Pack no encontrado.");
                }

                var CajaDto = caja.ToListDto();

                return Result<PackListDto>.Success(CajaDto);
            }
            catch (Exception ex)
            {
                return Result<PackListDto>.Failure(ex.Message);
            }
        }

        public Result<List<PackListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Packs.ObtenerTodos();
                var listaDto = lista.Select(b => b.ToListDto()).ToList();

                return Result<List<PackListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<PackListDto>>.Failure(ex.Message);
            }
        }
    }
}
