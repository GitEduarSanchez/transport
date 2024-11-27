using FluentValidation;

namespace Poliedro.Billing.Application.Concepto.Commands.Validator;

public class CreateConceptoCommandValidator : AbstractValidator<CreateConceptoCommand>
{
        public CreateConceptoCommandValidator()
        {
            RuleFor(x => x.descripcion)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.")
                .MaximumLength(100).WithMessage("La descripción no puede exceder los 100 caracteres.");
       }
}