using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SistemaGestionLibreria.Data;
using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Editorial;
using SistemaGestionLibreria.Services.Interfaces;
using SistemaGestionLibreria.Services.Mapeadores;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SistemaGestionLibreria.Services.Servicios
{
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<EditorialCreateDto> _createValidator;
        private readonly IValidator<EditorialUpdateDto> _updateValidator;
        public EditorialServicio(IUnitOfWork unitOfWork, IValidator<EditorialCreateDto> createValidator, IValidator<EditorialUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        public Result<int> Agregar(EditorialCreateDto editorialDto)
        {
            try
            {
                var validationResult = _createValidator.Validate(editorialDto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var editorial = EditorialMapper.ToEntidad(editorialDto);

                if (_unitOfWork.Editoriales.Existe(editorial))
                {
                    return Result<int>.Failure($"Ya existe una editorial con el nombre {editorial.Nombre}");
                }

                _unitOfWork.Editoriales.Agregar(editorial);
                _unitOfWork.Save();

                return Result<int>.Success(editorial.EditorialId);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar una editorial: {ex.Message}");
            }
        }

        public Result Borrar(EditorialDeleteDto editorialDto)
        {
            try
            {
                _unitOfWork.Editoriales.Borrar(editorialDto.EditorialId, editorialDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Editorial con ID: {editorialDto.EditorialId} no encontrada");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar una editorial: {ex.Message}");
            }
        }

        public Result Editar(EditorialUpdateDto editorialDto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(editorialDto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var entidad = EditorialMapper.ToEntidad(editorialDto);

                if (_unitOfWork.Editoriales.Existe(entidad))
                {
                    return Result.Failure($"Ya existe una editorial con el nombre {entidad.Nombre}");
                }

                _unitOfWork.Editoriales.Editar(entidad, entidad.EditorialId, editorialDto.RowVersion);
                _unitOfWork.Save();

                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (KeyNotFoundException)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Editorial con ID {editorialDto.EditorialId} no encontrada");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar la editorial: {ex.Message}");
            }
        }

        public Result<List<EditorialListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var query = _unitOfWork.Editoriales.Query();
                var lista = query.Where(tb => tb.Activo == activo);
                var listaDto = lista.Select(tb => EditorialMapper.ToListDto(tb)).ToList();
                return Result<List<EditorialListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<EditorialListDto>>.Failure($"Error al intentar filtrar las editoriales: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<EditorialListDto>> ObtenerPagina(int pagina, int cantidad, string campoOrdenar, bool esAscendente, bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Editorial, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));

                Func<IQueryable<Editorial>, IOrderedQueryable<Editorial>>? ordenarPor = campoOrdenar switch
                {
                    "EditorialId" => q => esAscendente ? q.OrderBy(tb => tb.EditorialId) : q.OrderByDescending(tb => tb.EditorialId),
                    _ => q => esAscendente ? q.OrderBy(tb => tb.Nombre) : q.OrderByDescending(tb => tb.Nombre),
                };

                var resultado = _unitOfWork.Editoriales.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(tb => EditorialMapper.ToListDto(tb)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<EditorialListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<EditorialListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<EditorialListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina, bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Editorial, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));


                var posicion = _unitOfWork.Editoriales.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<EditorialDeleteDto> ObtenerParaBorrar(int id)
        {
            var tipoBombon = _unitOfWork.Editoriales.ObtenerPorId(id);
            if (tipoBombon != null)
            {
                var tipoBombonDto = EditorialMapper.ToDeleteDto(tipoBombon);
                return Result<EditorialDeleteDto>.Success(tipoBombonDto);
            }

            return Result<EditorialDeleteDto>.Failure("Error al intentar obtener la editorial");
        }

        public Result<EditorialUpdateDto> ObtenerParaEditar(int id)
        {
            var tipoBombon = _unitOfWork.Editoriales.ObtenerPorId(id);
            if (tipoBombon != null)
            {
                var tipoBombonDto = EditorialMapper.ToUpdateDto(tipoBombon);
                return Result<EditorialUpdateDto>.Success(tipoBombonDto);
            }

            return Result<EditorialUpdateDto>.Failure("Editorial no encontrada!!!");
        }

        public Result<EditorialListDto> ObtenerPorId(int id)
        {
            try
            {
                var tipoBombon = _unitOfWork.Editoriales.ObtenerPorId(id);
                if (tipoBombon != null)
                {
                    var tipoBombonDto = EditorialMapper.ToListDto(tipoBombon);
                    return Result<EditorialListDto>.Success(tipoBombonDto);
                }

                return Result<EditorialListDto>.Failure("Editorial no encontrada!!!");
            }
            catch (Exception ex)
            {
                return Result<EditorialListDto>.Failure(ex.Message);
            }
        }

        public Result<List<EditorialListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Editoriales.ObtenerTodos();
                var listaDto = lista.Select(e => EditorialMapper.ToListDto(e)).ToList();
                return Result<List<EditorialListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<EditorialListDto>>.Failure(ex.Message);
            }
        }
    }
}
