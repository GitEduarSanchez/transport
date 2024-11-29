using FluentValidation;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands.Validator;

public class Createcontrolviaje_origenCommandValidator : AbstractValidator<Createcontrolviaje_origenCommand>
{
        public Createcontrolviaje_origenCommandValidator()
       {
        RuleFor(x => x.idcontrolviaje)
            .GreaterThan(0).WithMessage("El idcontrolviaje debe ser mayor que 0.");

        RuleFor(x => x.idorigen)
            .GreaterThan(0).WithMessage("El idorigen debe ser mayor que 0.");

        RuleFor(x => x.idciudad)
            .GreaterThan(0).WithMessage("El idciudad debe ser mayor que 0.");
    }
}
