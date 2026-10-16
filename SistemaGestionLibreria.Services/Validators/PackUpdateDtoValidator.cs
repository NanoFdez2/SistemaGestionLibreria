using FluentValidation;
using SistemaGestionLibreria.Services.DTO.Pack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Validators
{
    public class PackUpdateDtoValidator : AbstractValidator<PackUpdateDto>
    {
        public PackUpdateDtoValidator()
        {
            RuleFor (x=> x.Titulo)
                .NotEmpty().WithMessage("El título no puede estar vacío.")
                .MaximumLength(100).WithMessage("El título no puede tener más de 100 caracteres.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.")
                .MaximumLength(500).WithMessage("La descripción no puede tener más de 500 caracteres.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");

            RuleFor(x=> x.RowVersion)
                .NotNull().WithMessage("La versión de fila no puede ser nula.");
        }
    }
}
