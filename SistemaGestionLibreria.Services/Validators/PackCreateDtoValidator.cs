using FluentValidation;
using SistemaGestionLibreria.Services.DTO.Pack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Validators
{
    public class PackCreateDtoValidator : AbstractValidator<PackCreateDto>
    {
        public PackCreateDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título no puede estar vacío.")
                .MaximumLength(100).WithMessage("El título no puede tener más de 100 caracteres.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.")
                .MaximumLength(500).WithMessage("La descripción no puede tener más de 500 caracteres.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");

            RuleFor(x => x.CantidadLibros)
                .GreaterThanOrEqualTo(1).WithMessage("La cantidad de libros debe ser un valor positivo.");

        }
    }
}
