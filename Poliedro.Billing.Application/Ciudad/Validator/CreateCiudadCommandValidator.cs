using FluentValidation;

namespace Poliedro.Billing.Application.Ciudad.Commands.Validator;

public class CreateCiudadCommandValidator : AbstractValidator<CreateCiudadCommand>
{
        public CreateCiudadCommandValidator()
        {
        RuleFor(x => x.descripcion)
            .NotEmpty().WithMessage("La descripción es obligatoria.")
            .MaximumLength(100).WithMessage("La descripción no puede exceder los 100 caracteres.");

        RuleFor(x => x.iddepartamento)
            .GreaterThan(0).WithMessage("El ID del departamento debe ser un número positivo.");
    }
}
