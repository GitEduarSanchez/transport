using FluentValidation;
using Poliedro.Billing.Application.Origen.Commands.CreateServerCommand;

namespace Poliedro.Billing.Application.Origen.Commands.Validator;

public class CreateOrigenCommandValidator : AbstractValidator<CreateOrigenCommand>
{
          public CreateOrigenCommandValidator()
    {
        RuleFor(command => command.descripcion)
            .NotEmpty().WithMessage("La descripción no puede estar vacía.")
            .MaximumLength(200).WithMessage("La descripción no puede tener más de 200 caracteres.")
            .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("La descripción solo puede contener letras, números y espacios.");
    }
}
