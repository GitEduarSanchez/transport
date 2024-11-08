using MediatR;

namespace Poliedro.Billing.Application.Producto.Commands.CreateServerCommand;

public record CreateConductorCommand(string Name) : IRequest<bool>;