using FluentValidation;

namespace Poliedro.Billing.Application.Estado.Commands.Validator;

public class CreateEstadoCommandValidator : AbstractValidator<CreateEstadoCommand>
{
        public CreateEstadoCommandValidator()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.")
                .MaximumLength(100).WithMessage("La descripción no puede exceder los 100 caracteres.");
       }
}
