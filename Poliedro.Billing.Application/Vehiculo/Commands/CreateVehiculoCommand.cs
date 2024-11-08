using MediatR;

namespace Poliedro.Billing.Application.Conductor.Commands.CreateServerCommand;

public record CreateVehiculoCommand(string Name) : IRequest<bool>;