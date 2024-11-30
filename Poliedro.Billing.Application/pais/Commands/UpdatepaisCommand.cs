using MediatR;
using Poliedro.Billing.Domain.pais.Request;

namespace Poliedro.Billing.Application.pais.Commands;

public record UpdatepaisCommand(int Id, paisRequest paisEntity) : IRequest<Unit>;

