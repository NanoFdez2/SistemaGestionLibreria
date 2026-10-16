using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SistemaGestionLibreria.Data;
using SistemaGestionLibreria.Entities;
using SistemaGestionLibreria.Entities.Enums;
using SistemaGestionLibreria.Services.Common;
using SistemaGestionLibreria.Services.DTO.Libro;
using SistemaGestionLibreria.Services.Interfaces;
using SistemaGestionLibreria.Services.Mapeadores;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using static Azure.Core.HttpHeader;

namespace SistemaGestionLibreria.Services.Servicios
{
    public class LibroServicio : ILibroServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<LibroCreateDto> _createValidator;
        private readonly IValidator<LibroUpdateDto> _updateValidator;
        public LibroServicio(IUnitOfWork unitOfWork, IValidator<LibroCreateDto> createValidator, IValidator<LibroUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        public Result<int> Agregar(LibroCreateDto libroDto)
        {
            var validationResult = _createValidator.Validate(libroDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result<int>.Failure(errors);
            }

            var Libro = LibroMapper.ToEntidad(libroDto);

            if (_unitOfWork.Libros.Existe(Libro))
            {
                return Result<int>.Failure("El Libro ya existe.");
            }

            try
            {
                _unitOfWork.Libros.Agregar(Libro);
                _unitOfWork.Save();
                return Result<int>.Success(Libro.Id);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                var mensajeError = new StringBuilder();
                mensajeError.AppendLine($"Error al intentar agregar el Libro: {ex.Message}");

                var excepcionInterna = ex.InnerException;
                int nivelProundidad = 1;
                while (excepcionInterna != null && nivelProundidad < 5)
                {
                    mensajeError.AppendLine($"Inner Exception [{nivelProundidad}]: {excepcionInterna.Message}");
                    excepcionInterna = excepcionInterna.InnerException;
                    nivelProundidad++;
                }

                return Result<int>.Failure(mensajeError.ToString());
            }
        }

        public Result Borrar(LibroDeleteDto libroDto)
        {
            try
            {
                _unitOfWork.Libros.Borrar(libroDto.productoId);
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
                return Result.Failure($"Libro con ID: {libroDto.productoId} no encontrado");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar un libro: {ex.Message}");
            }
        }

        public Result Editar(LibroUpdateDto libroDto)
        {
            var validationResult = _updateValidator.Validate(libroDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Failure(errors);
            }

            var libro = _unitOfWork.Libros.ObtenerPorId(libroDto.ProductoId);
            if (libro == null)
            {
                return Result.Failure("Libro no encontrado.");
            }

            libro.Titulo = libroDto.Titulo;
            libro.ISBN = libroDto.ISBN;
            libro.Descripcion = libroDto.Descripcion;
            libro.Precio = libroDto.Precio;
            libro.Stock = libroDto.Stock;
            libro.AnioPublicacion = libroDto.AnioPublicacion;
            libro.Activo = libroDto.Activo;

            if (_unitOfWork.Libros.Existe(libro))
            {
                return Result.Failure("Ya existe otro Libro registrado con los mismos datos.");
            }

            try
            {
                _unitOfWork.Libros.Editar(libro, libro.Id);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el Libro: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<LibroListDto>> ObtenerPaginado(int paginaActual, int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo, string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Libro, bool>>? filtro = l =>
                        (!filtroActivo.HasValue || l.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || l.Titulo.Contains(textoBuscar));
                Func<IQueryable<Libro>, IOrderedQueryable<Libro>>? ordenarPor = campoOrdenar switch
                {
                    "TipoLibroId" => q => esAscendente ? q.OrderBy(c => c.Id) : q.OrderByDescending(c => c.Id),
                    "Titulo" => q => esAscendente ? q.OrderBy(c => c.Titulo) : q.OrderByDescending(c => c.Titulo),
                    _ => q => esAscendente ? q.OrderBy(c => c.Titulo) : q.OrderByDescending(c => c.Titulo),
                };

                Func<IQueryable<Libro>, IQueryable<Libro>>? incluir = q => q.Include(c => c.Editorial); // Incluir Editorial
                var resultado = _unitOfWork.Libros.ObtenerPagina(paginaActual, cantidadPorPagina, ordenarPor, filtro, incluir);
                var listaDto = resultado.lista
                    .Select(b => b.ToListDto()).ToList();

                var resultadoPaginado = new ResultadoPaginacionDto<LibroListDto>()
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = cantidadPorPagina,
                    PaginaActual = paginaActual
                };

                return Result<ResultadoPaginacionDto<LibroListDto>>.Success(resultadoPaginado);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<LibroListDto>>.Failure($"Error al intentar paginar: {ex.Message}");
            }
        }

        public Result<int> ObtenerPaginaRegistro(int seleccionadoId, int cantidadPorPagina, bool? filtroActivo = null)
        {
            try
            {
                Expression<Func<Libro, bool>>? filtrarPor = null;
                if (filtroActivo is not null)
                {
                    filtrarPor = b => b.Activo == filtroActivo;
                }

                var posicion = _unitOfWork.Libros.ObtenerPosicionRegistro(seleccionadoId, filtrarPor);
                var pagina = (int)Math.Ceiling((double)posicion / cantidadPorPagina);
                return Result<int>.Success(pagina);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure($"Error al intentar obtener la página: {ex.Message}");
            }
        }

        public Result<LibroDeleteDto> ObtenerParaBorrar(int productoId)
        {
            var bombon = _unitOfWork.Libros.ObtenerPorId(productoId);
            if (bombon != null)
            {
                var bombonDto = LibroMapper.ToDeleteDto(bombon);
                return Result<LibroDeleteDto>.Success(bombonDto);
            }

            return Result<LibroDeleteDto>.Failure("Error al intentar obtener el libro");
        }

        public Result<LibroUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var libro = _unitOfWork.Libros.ObtenerPorId(id);
                if (libro == null)
                {
                    return Result<LibroUpdateDto>.Failure("Libro no encontrado.");
                }

                var libroDto = libro.ToUpdateDto();
                return Result<LibroUpdateDto>.Success(libroDto);
            }
            catch (Exception ex)
            {
                return Result<LibroUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<LibroListDto> ObtenerPorId(int id)
        {
            try
            {
                var libro = _unitOfWork.Libros.ObtenerPorId(id);
                if (libro == null)
                {
                    return Result<LibroListDto>.Failure("Libro no encontrado.");
                }

                var libroDto = libro.ToListDto();

                return Result<LibroListDto>.Success(libroDto);
            }
            catch (Exception ex)
            {
                return Result<LibroListDto>.Failure(ex.Message);
            }
        }

        public Result<List<LibroListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Libros.ObtenerTodos();
                var listaDto = lista.Select(l => l.ToListDto()).ToList();

                return Result<List<LibroListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<LibroListDto>>.Failure(ex.Message);
            }
        }

        public Result<List<LibroComboDto>> ObtenerDatosCombo(Entities.Enums.LibroDefault defaultLibro, bool activos)
        {
            try
            {
                var lista = _unitOfWork.Libros.ObtenerTodos();

                // Filtrar solo activos si es necesario
                if (activos)
                {
                    lista = lista.Where(l => l.Activo).ToList();
                }

                // Crear DTO del combo
                var listaCombo = lista.Select(l => new LibroComboDto
                {
                    LibroId = l.Id,
                    Titulo = l.Titulo,
                    Precio = l.Precio,
                    ISBN = l.ISBN,
                    AnioPublicacion = l.AnioPublicacion,
                    Activo = l.Activo,
                    Stock = l.Stock
                }).ToList();
                var comboDefault = new LibroComboDto
                {
                    LibroId = 0,
                    Titulo = defaultLibro.ToString(),
                    Precio = 0,
                    ISBN = string.Empty,
                    AnioPublicacion = 0,
                    Activo = true,
                    Stock = 0
                };
                listaCombo.Insert(0, comboDefault);

                return Result<List<LibroComboDto>>.Success(listaCombo);
            }
            catch (Exception ex)
            {
                return Result<List<LibroComboDto>>.Failure(ex.Message);
            }
        }
    }
}
