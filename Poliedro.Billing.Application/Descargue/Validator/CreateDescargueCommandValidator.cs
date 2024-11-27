using FluentValidation;

namespace Poliedro.Billing.Application.Descargue.Commands.Validator;

public class CreateDescargueCommandValidator : AbstractValidator<CreateDescargueCommand>
{
        public CreateDescargueCommandValidator()
        {
            RuleFor(x => x.descriocion)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.")
                .MaximumLength(100).WithMessage("La descripción no puede exceder los 100 caracteres.");
       }
}
