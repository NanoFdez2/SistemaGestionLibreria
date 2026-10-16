using FluentValidation;
using SistemaGestionLibreria.Services.DTO.Tema;

namespace SistemaGestionLibreria.Services.Validators
{
    public class TemaCreateDtoValidator : AbstractValidator<TemaCreateDto>
    {
        public TemaCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del tema es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre del tema no puede exceder los 100 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción del tema no puede exceder los 500 caracteres.");

        }
    }
}
