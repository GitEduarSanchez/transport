using MediatR;

namespace Poliedro.Billing.Application.Vehiculo.Commands;

public record CreateVehiculoCommand(string Name) : IRequest<bool>;