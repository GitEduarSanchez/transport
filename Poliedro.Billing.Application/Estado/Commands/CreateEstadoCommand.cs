using MediatR;

namespace Poliedro.Billing.Application.Estado.Commands.CreateServerCommand;

public record CreateEstadoCommand(string descripcion) : IRequest<bool>;
