using FluentValidation;

namespace Poliedro.Billing.Application.ControlViajeProducto.Commands.Validator;

public class CreateControlViajeProductoCommandValidator : AbstractValidator<CreateControlViajeProductoCommand>
{
        public CreateControlViajeProductoCommandValidator()
        {
             RuleFor(command => command.idControlViaje)
            .GreaterThan(0).WithMessage("El idControlViaje debe ser mayor que cero.");

        RuleFor(command => command.idProducto)
            .GreaterThan(0).WithMessage("El idProducto debe ser mayor que cero.");
       }
}
