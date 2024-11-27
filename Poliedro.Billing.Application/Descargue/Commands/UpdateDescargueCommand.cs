using MediatR;
using Poliedro.Billing.Domain.Descargue.Request;

namespace Poliedro.Billing.Application.Descargue.Commands;

public record UpdateDescargueCommand(int Id, DescargueRequest DescargueEntity) : IRequest<Unit>;

