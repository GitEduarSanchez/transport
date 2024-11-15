using MediatR;

namespace Poliedro.Billing.Application.Estado.Commands;

public record CreateEstadoCommand(string Descripcion) : IRequest<bool>;
