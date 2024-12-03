using FluentValidation;
using Poliedro.Billing.Application.unidad_medida.commands;

namespace Poliedro.Billing.Application.unidad_medida.Commands.Validator;

public class Createunidad_medidaCommandValidator : AbstractValidator<Createunidad_medidaCommand>
{
        public Createunidad_medidaCommandValidator()
        {
            RuleFor(x => x.descripcion)
                .NotEmpty().WithMessage("La descripción no puede estar vacía.")
                .MaximumLength(100).WithMessage("La descripción no puede exceder los 100 caracteres.");
       }
}
