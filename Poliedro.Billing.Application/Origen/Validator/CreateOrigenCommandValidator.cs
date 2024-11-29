using FluentValidation;

namespace Poliedro.Billing.Application.Origen.Commands.Validator;

public class CreateOrigenCommandValidator : AbstractValidator<CreateOrigenCommand>
{
        public CreateOrigenCommandValidator()
        {
            RuleFor(x => x.descripcion)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.")
                .MaximumLength(100).WithMessage("La descripción no puede exceder los 100 caracteres.");
       }
}
