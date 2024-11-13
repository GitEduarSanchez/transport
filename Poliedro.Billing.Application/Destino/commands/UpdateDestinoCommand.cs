using MediatR;
using Poliedro.Billing.Domain.Destino.Request;

namespace Poliedro.Billing.Application.Destino.Commands;

public record UpdateDestinoCommand(int Id, DestinoRequest DestinoEntity) : IRequest<Unit>;

