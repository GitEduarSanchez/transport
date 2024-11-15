using MediatR;
using Poliedro.Billing.Application.Descargue.Dto;

namespace Poliedro.Billing.Application.Descargue.Query;

public record GetByiddescargueQuery(int iddescargue) : IRequest<DescargueDto>;

