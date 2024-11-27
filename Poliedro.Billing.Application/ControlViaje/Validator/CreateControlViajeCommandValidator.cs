using FluentValidation;

namespace Poliedro.Billing.Application.ControlViaje.Commands.Validator;

public class CreateControlViajeCommandValidator : AbstractValidator<CreateControlViajeCommand>
{
        public CreateControlViajeCommandValidator()
        {
        // Validar que la fecha no sea una fecha futura
        RuleFor(x => x.fecha)
            .NotEmpty().WithMessage("La fecha es obligatoria.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha no puede ser en el futuro.");

        // Validar que la guía no esté vacía
        RuleFor(x => x.guia)
            .NotEmpty().WithMessage("La guía es obligatoria.")
            .MaximumLength(50).WithMessage("La guía no puede tener más de 50 caracteres.");

        // Validar que el ID de Vehículo no sea 0 ni negativo
        RuleFor(x => x.idVehiculoTrailer)
            .GreaterThan(0).WithMessage("El ID del vehículo debe ser mayor que 0.");
    }
}
