using FluentValidation;
using SistemaGestionLibreria.Data;
using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Autor;
using SistemaGestionLibreria.Services.Interfaces;
using SistemaGestionLibreria.Services.Mapeadores;
using System.Linq.Expressions;

namespace SistemaGestionLibreria.Services.Servicios
{
    public class AutorServicio : IAutorServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AutorCreateDto> _createValidator;
        private readonly IValidator<AutorUpdateDto> _updateValidator;
        public AutorServicio(IUnitOfWork unitOfWork, IValidator<AutorCreateDto> createValidator, IValidator<AutorUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        public Result<int> Agregar(AutorCreateDto autorDto)
        {
            var validationResult = _createValidator.Validate(autorDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<int>.Failure(errors);
            }

            var autor = AutorMapper.ToEntidad(autorDto);

            if (_unitOfWork.Autores.Existe(autor))
            {
                return Result<int>.Failure("El autor ya existe.");
            }

            try
            {
                _unitOfWork.Autores.Agregar(autor);
                _unitOfWork.Save();
                return Result<int>.Success(autor.AutorId);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar agregar el autor: {ex.Message}");
            }
        }

        public Result Borrar(int id)
        {
            var autor = _unitOfWork.Autores.ObtenerPorId(id);
            if (autor == null)
            {
                return Result.Failure("Autor no encontrado.");
            }

            try
            {
                _unitOfWork.Autores.Borrar(autor.AutorId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar el autor: {ex.Message}");
            }
        }

        public Result Editar(AutorUpdateDto autorDto)
        {
            var validationResult = _updateValidator.Validate(autorDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Failure(errors);
            }

            var autor = _unitOfWork.Autores.ObtenerPorId(autorDto.AutorId);
            if (autor == null)
            {
                return Result.Failure("Autor no encontrado.");
            }

            autor.Nombre = autorDto.Nombre;
            autor.Apellido = autorDto.Apellido;
            autor.Nacionalidad = autorDto.Nacionalidad;
            autor.FechaDeNacimiento = autorDto.FechaDeNacimiento;




            if (_unitOfWork.Autores.Existe(autor))
            {
                return Result.Failure("Ya existe otro autor registrado con los mismos datos.");
            }

            try
            {
                _unitOfWork.Autores.Editar(autor, autor.AutorId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el autor: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<AutorListDto>> ObtenerPaginado(int paginaActual, int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Autores, bool>>? filtro = c =>
                        (!filtroActivo.HasValue || c.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || c.Nombre.Contains(textoBuscar));

                Func<IQueryable<Autores>, IOrderedQueryable<Autores>>? ordenarPor = campoOrdenar switch
                {
                    "Apellido" => q => esAscendente ? q.OrderBy(c => c.Apellido) : q.OrderByDescending(c => c.Apellido),
                    "Nacionalidad" => q => esAscendente ? q.OrderBy(c => c.Nacionalidad) : q.OrderByDescending(c => c.Nacionalidad),
                    "FechaDeNacimiento" => q => esAscendente ? q.OrderBy(c => c.FechaDeNacimiento) : q.OrderByDescending(c => c.FechaDeNacimiento),
                    _ => q => esAscendente ? q.OrderBy(c => c.Nombre) : q.OrderByDescending(c => c.Nombre),
                };

                var resultado = _unitOfWork.Autores.ObtenerPagina(paginaActual, cantidadPorPagina, ordenarPor, filtro);
                var listaDto = resultado.lista
                    .Select(c => AutorMapper.ToListDto(c)).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<AutorListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidadPorPagina,
                    PaginaActual = paginaActual
                };

                return Result<ResultadoPaginacionDto<AutorListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<AutorListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<AutorUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var autor = _unitOfWork.Autores.ObtenerPorId(id);
                if (autor == null)
                {
                    return Result<AutorUpdateDto>.Failure("Autor no encontrado.");
                }

                var autorDto = new AutorUpdateDto
                {
                    AutorId = autor.AutorId,
                    Nombre = autor.Nombre,
                    Apellido = autor.Apellido,
                    Nacionalidad = autor.Nacionalidad,
                    FechaDeNacimiento = autor.FechaDeNacimiento,
                    RowVersion = autor.RowVersion
                };

                return Result<AutorUpdateDto>.Success(autorDto);
            }
            catch (Exception ex)
            {
                return Result<AutorUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<AutorListDto> ObtenerPorId(int id)
        {
            try
            {
                var cliente = _unitOfWork.Autores.ObtenerPorId(id);
                if (cliente == null)
                {
                    return Result<AutorListDto>.Failure("Autor no encontrado.");
                }

                var autorDto = new AutorListDto
                {
                    AutorId = cliente.AutorId,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Nacionalidad = cliente.Nacionalidad,
                    FechaDeNacimiento = cliente.FechaDeNacimiento

                };

                return Result<AutorListDto>.Success(autorDto);
            }
            catch (Exception ex)
            {
                return Result<AutorListDto>.Failure(ex.Message);
            }
        }

        public Result<List<AutorListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Autores.ObtenerTodos();
                var listaDto = lista.Select(c => new AutorListDto
                {
                    AutorId = c.AutorId,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Nacionalidad = c.Nacionalidad,
                    FechaDeNacimiento = c.FechaDeNacimiento
                }).ToList();

                return Result<List<AutorListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<AutorListDto>>.Failure(ex.Message);
            }
        }
    }
}
