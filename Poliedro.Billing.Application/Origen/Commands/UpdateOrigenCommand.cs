using MediatR;
using Poliedro.Billing.Domain.Origen.Request;

namespace Poliedro.Billing.Application.Origen.Commands;

public record UpdateOrigenCommand(int Id, OrigenRequest OrigenEntity) : IRequest<Unit>;

