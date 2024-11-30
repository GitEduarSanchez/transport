using FluentValidation;

namespace Poliedro.Billing.Application.pais.Commands.Validator;

public class CreatepaisCommandValidator : AbstractValidator<CreatepaisCommand>
{
        public CreatepaisCommandValidator()
        {
        RuleFor(x => x.descripcion)
            .NotEmpty().WithMessage("La descripción no puede estar vacía.")
            .MaximumLength(100).WithMessage("La descripción no puede superar los 100 caracteres.");
    }
}
