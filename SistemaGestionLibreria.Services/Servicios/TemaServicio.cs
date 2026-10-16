using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SistemaGestionLibreria.Data;
using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Entities.Enums;
using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Tema;
using SistemaGestionLibreria.Services.Interfaces;
using SistemaGestionLibreria.Services.Mapeadores;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SistemaGestionLibreria.Services.Servicios
{
    public class TemaServicio : ITemaServicio
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IValidator<TemaCreateDto>? _createValidator;
        private readonly IValidator<TemaUpdateDto>? _updateValidator;
        public TemaServicio(IUnitOfWork? unitOfWork, IValidator<TemaCreateDto>? createValidator, IValidator<TemaUpdateDto>? updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        public Result<int> Agregar(TemaCreateDto temaDto)
        {
            try
            {
                var validationResult = _createValidator.Validate(temaDto);
                if (!validationResult.IsValid)
                {
                    return Result<int>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var tema = TemaMapper.ToEntidad(temaDto);

                if (_unitOfWork.Temas.Existe(tema))
                {
                    return Result<int>.Failure($"Ya existe un tema con el nombre {tema.Nombre}");
                }

                _unitOfWork.Temas.Agregar(tema);
                _unitOfWork.Save();

                return Result<int>.Success(tema.TemaId);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar un tema: {ex.Message}");
            }
        }

        public Result Borrar(TemaDeleteDto temaDto)
        {
            try
            {
                _unitOfWork.Temas.Borrar(temaDto.TemaId, temaDto.RowVersion);
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
                return Result.Failure($"Tema con ID: {temaDto.TemaId} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar un tema: {ex.Message}");
            }
        }

        public Result Editar(TemaUpdateDto temaDto)
        {
            try
            {
                var validationResult = _updateValidator.Validate(temaDto);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }

                var entidad = TemaMapper.ToEntidad(temaDto);

                if (_unitOfWork.Temas.Existe(entidad))
                {
                    return Result.Failure($"Ya existe un tema con el nombre {entidad.Nombre}");
                }

                _unitOfWork.Temas.Editar(entidad, entidad.TemaId, temaDto.RowVersion);      
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
                return Result.Failure($"Tema con ID {temaDto.TemaId} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el tema: {ex.Message}");
            }
        }

        public Result<List<TemaListDto>> FiltrarPorActivo(bool activo)
      
        {
            try
            {
                var query = _unitOfWork.Temas.Query();
                var lista = query.Where(tb => tb.Activo == activo);
                var listaDto = lista.Select(tb => TemaMapper.ToListDto(tb)).ToList();
                return Result<List<TemaListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<TemaListDto>>.Failure($"Error al intentar filtrar los temas: {ex.Message}");
            }
        }

        public Result<List<TemaListDto>> ObtenerDatosCombo(TemaDefault temaDefault)
        {
            var lista = _unitOfWork.Temas.ObtenerTodos()
                            .Select(tp => TemaMapper.ToListDto(tp)).ToList();
            if (temaDefault == TemaDefault.Todos)
            {
                var defaultTipo = new TemaListDto
                {
                    TemaId = 0,
                    Nombre = "Todos"
                };
                lista.Insert(0, defaultTipo);

            }
            else
            {
                var defaultTipo = new TemaListDto
                {
                    TemaId = 0,
                    Nombre = "Seleccione"
                };
                lista.Insert(0, defaultTipo);
            }
            return Result<List<TemaListDto>>.Success(lista);
        }

        public Result<ResultadoPaginacionDto<TemaListDto>> ObtenerPagina(int pagina, int cantidad, string campoOrdenar, bool esAscendente, bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Tema, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));

                Func<IQueryable<Tema>, IOrderedQueryable<Tema>>? ordenarPor = campoOrdenar switch
                {
                    "TemaId" => q => esAscendente ? q.OrderBy(tb => tb.TemaId) : q.OrderByDescending(tb => tb.TemaId),
                    _ => q => esAscendente ? q.OrderBy(tb => tb.Nombre) : q.OrderByDescending(tb => tb.Nombre),
                };

                var resultado = _unitOfWork.Temas.ObtenerPagina(pagina, cantidad, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(tb => TemaMapper.ToListDto(tb)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<TemaListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidad,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<TemaListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<TemaListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina, bool? filtroActivo = null, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Tema, bool>>? filtro = b =>
                        (!filtroActivo.HasValue || b.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || b.Nombre.Contains(textoBuscar));


                var posicion = _unitOfWork.Temas.ObtenerPosicionRegistro(seleccionadoId, filtro);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<TemaDeleteDto> ObtenerParaBorrar(int id)
        {
            var tipoBombon = _unitOfWork.Temas.ObtenerPorId(id);
            if (tipoBombon != null)
            {
                var tipoBombonDto = TemaMapper.ToDeleteDto(tipoBombon);
                return Result<TemaDeleteDto>.Success(tipoBombonDto);
            }

            return Result<TemaDeleteDto>.Failure("Error al intentar obtener el tema");
        }

        public Result<TemaUpdateDto> ObtenerParaEditar(int id)
        {
            var tipoBombon = _unitOfWork.Temas.ObtenerPorId(id);
            if (tipoBombon != null)
            {
                var tipoBombonDto = TemaMapper.ToUpdateDto(tipoBombon);
                return Result<TemaUpdateDto>.Success(tipoBombonDto);
            }

            return Result<TemaUpdateDto>.Failure("Tema no encontrado!!!");
        }

        public Result<TemaListDto> ObtenerPorId(int id)
        {
            try
            {
                var tipoBombon = _unitOfWork.Temas.ObtenerPorId(id);
                if (tipoBombon != null)
                {
                    var tipoBombonDto = TemaMapper.ToListDto(tipoBombon);
                    return Result<TemaListDto>.Success(tipoBombonDto);
                }

                return Result<TemaListDto>.Failure("Tema no encontrado!!!");
            }
            catch (Exception ex)
            {
                return Result<TemaListDto>.Failure(ex.Message);
            }
        }

        public Result<List<TemaListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Temas.ObtenerTodos();
                var listaDto = lista.Select(t => TemaMapper.ToListDto(t)).ToList();
                return Result<List<TemaListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<TemaListDto>>.Failure(ex.Message);
            }
        }
    }
}
