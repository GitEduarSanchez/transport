using FluentValidation;

namespace Poliedro.Billing.Application.departamento.Commands.Validator;

public class CreatedepartamentoCommandValidator : AbstractValidator<CreatedepartamentoCommand>
{
        public CreatedepartamentoCommandValidator()
        {
        RuleFor(command => command.descripcion)
            .NotEmpty().WithMessage("La descripción no puede estar vacía.")
            .MaximumLength(100).WithMessage("La descripción no puede exceder los 100 caracteres.");

        RuleFor(command => command.idpais)
            .GreaterThan(0).WithMessage("El ID del país debe ser un número positivo.");
    }
}
