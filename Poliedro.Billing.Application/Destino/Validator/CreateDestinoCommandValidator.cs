using FluentValidation;

namespace Poliedro.Billing.Application.Destino.Commands.Validator;

public class CreateDestinoCommandValidator : AbstractValidator<CreateDestinoCommand>
{
        public CreateDestinoCommandValidator()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.")
                .MaximumLength(100).WithMessage("La descripción no puede exceder los 100 caracteres.");
       }
}
