using MediatR;
using Poliedro.Billing.Domain.Estado.Request;

namespace Poliedro.Billing.Application.Estado.Commands;

public record UpdateEstadoCommand(int Id, EstadoRequest EstadoEntity) : IRequest<Unit>;

