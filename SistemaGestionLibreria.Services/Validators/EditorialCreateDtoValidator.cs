using FluentValidation;
using SistemaGestionLibreria.Services.DTO.Editorial;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Validators
{
    public class EditorialCreateDtoValidator : AbstractValidator<EditorialCreateDto>
    {
        public EditorialCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la editorial es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre de la editorial no puede exceder los 100 caracteres.");
            RuleFor(x => x.PaisDeOrigen)
                .NotEmpty().WithMessage("El país de origen de la editorial es obligatorio.")
                .MaximumLength(50).WithMessage("El país de origen de la editorial no puede exceder los 50 caracteres.");
        }
    }
}
