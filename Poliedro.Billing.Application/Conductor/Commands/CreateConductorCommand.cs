using MediatR;

namespace Poliedro.Billing.Application.Conductor.Commands;

public record CreateConductorCommand(string Name) : IRequest<bool>;