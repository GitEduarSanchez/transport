using MediatR;

namespace Poliedro.Billing.Application.unidad_medida.commands;

public record Createunidad_medidaCommand(string descripcion) : IRequest<bool>;