using MediatR;
using Poliedro.Billing.Application.Descargue.Dto;

namespace Poliedro.Billing.Application.Descargue.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<DescargueDto>>;

