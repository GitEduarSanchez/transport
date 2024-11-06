using MediatR;

namespace Poliedro.Billing.Application.Estado.Commands;

public record DeleteEstadoCommand(int Id) : IRequest<bool>;

