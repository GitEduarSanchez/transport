using FluentValidation;
using Poliedro.Billing.Application.Producto.commands;

namespace Poliedro.Billing.ApplicationProducto.Commands.Validator;

public class CreateProductoCommandValidator : AbstractValidator<CreateProductoCommand>
{
        public CreateProductoCommandValidator()
         {
        // Regla para la propiedad "descripcion": No puede estar vacía ni nula
        RuleFor(command => command.descripcion)
            .NotEmpty().WithMessage("La descripción es obligatoria.")
            .MaximumLength(255).WithMessage("La descripción no puede exceder los 255 caracteres.");

        // Regla para la propiedad "idunidad_medida": Debe ser mayor que 0
        RuleFor(command => command.idunidad_medida)
            .GreaterThan(0).WithMessage("El ID de la unidad de medida debe ser mayor que 0.");
    }
}
