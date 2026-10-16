using FluentValidation;
using SistemaGestionLibreria.Services.DTO.Autor;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Validators
{
    public class AutorUpdateDtoValidator : AbstractValidator<AutorUpdateDto>
    {
        public AutorUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del autor es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre del autor no puede exceder los 100 caracteres.");
            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido del autor es obligatorio.")
                .MaximumLength(100).WithMessage("El apellido del autor no puede exceder los 100 caracteres.");
            RuleFor(x => x.FechaDeNacimiento)
                .NotEmpty().WithMessage("La fecha de nacimiento del autor es obligatoria.")
                .LessThan(DateTime.Now).WithMessage("La fecha de nacimiento del autor debe ser anterior a la fecha actual.");
            RuleFor(x => x.Nacionalidad)
                .NotEmpty().WithMessage("La nacionalidad del autor es obligatoria.")
                .MaximumLength(50).WithMessage("La nacionalidad del autor no puede exceder los 50 caracteres.");
            RuleFor(x => x.RowVersion)
                .NotNull().WithMessage("La versión de fila no puede ser nula.");
        }
    }
}
