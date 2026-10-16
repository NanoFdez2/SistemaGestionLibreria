using FluentValidation;
using SistemaGestionLibreria.Services.DTO.Tema;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Validators
{
    public class TemaUpdateDtoValidator : AbstractValidator<TemaUpdateDto>
    {
        public TemaUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del tema es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre del tema no puede exceder los 100 caracteres.");
            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción del tema no puede exceder los 500 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotNull().WithMessage("El RowVersion es obligatorio para la actualización del tema.");

        }
    }
}
