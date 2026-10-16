using FluentValidation;
using SistemaGestionLibreria.Services.DTO.Libro;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaGestionLibreria.Services.Validators
{
    public class LibroCreateDtoValidator : AbstractValidator<LibroCreateDto>
    {
        public LibroCreateDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(100).WithMessage("El título no puede exceder los 100 caracteres.");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("El ISBN es obligatorio.")
                .Matches(@"^\d{3}-\d{10}$").WithMessage("El ISBN debe tener el formato correcto (ejemplo: 978-1234567890).");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que cero.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");

            RuleFor(x => x.AnioPublicacion)
                .NotEmpty().WithMessage("El año de publicación es obligatorio.")
                .InclusiveBetween(1000, DateTime.Now.Year).WithMessage("El año de publicación no es válido.");

            RuleFor(x=>x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock debe ser un valor no negativo.");

        }
    }
}
