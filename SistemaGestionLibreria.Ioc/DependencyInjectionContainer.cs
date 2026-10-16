using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionLibreria.Data;
using SistemaGestionLibreria.Data.Repositorios;
using SistemaGestionLibreria.Data.Interfaces;

using SistemaGestionLibreria.Data.Context;
using SistemaGestionLibreria.Services.Servicios;
using SistemaGestionLibreria.Services.Interfaces;
using SistemaGestionLibreria.Services.DTO.Editorial;
using SistemaGestionLibreria.Services.Validators;
using SistemaGestionLibreria.Services.DTO.Tema;
using SistemaGestionLibreria.Services.DTO.Autor;
using SistemaGestionLibreria.Services.DTO.Libro;
using SistemaGestionLibreria.Services.DTO.Pack;


namespace SistemaGestionLibreria.Ioc
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddDbContext<SistemaGestionLibreriaContext>();

            services.AddScoped<IEditorialRepositorio, EditorialRepositorio>();
            services.AddScoped<IEditorialServicio, EditorialServicio>();
            services.AddScoped<IValidator<EditorialCreateDto>, EditorialCreateDtoValidator>();
            services.AddScoped<IValidator<EditorialUpdateDto>, EditorialUpdateDtoValidator>();

            services.AddScoped<ITemaRepositorio, TemaRepositorio>();
            services.AddScoped<ITemaServicio, TemaServicio>();
            services.AddScoped<IValidator<TemaCreateDto>, TemaCreateDtoValidator>();
            services.AddScoped<IValidator<TemaUpdateDto>, TemaUpdateDtoValidator>();

            services.AddScoped<IAutoresRepositorio, AutoresRepositorio>();
            services.AddScoped<IAutorServicio, AutorServicio>();
            services.AddScoped<IValidator<AutorCreateDto>, AutorCreateDtoValidator>();
            services.AddScoped<IValidator<AutorUpdateDto>, AutorUpdateDtoValidator>();

            services.AddScoped<ILibroRepositorio, LibroRepositorio>();
            services.AddScoped<ILibroServicio, LibroServicio>();
            services.AddScoped<IValidator<LibroCreateDto>, LibroCreateDtoValidator>();
            services.AddScoped<IValidator<LibroUpdateDto>, LibroUpdateDtoValidator>();

            services.AddScoped<IPackRepositorio, PackRepositorio>();
            services.AddScoped<IPackServicio, PackServicio>();
            services.AddScoped<IValidator<PackCreateDto>, PackCreateDtoValidator>();
            services.AddScoped<IValidator<PackUpdateDto>, PackUpdateDtoValidator>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
