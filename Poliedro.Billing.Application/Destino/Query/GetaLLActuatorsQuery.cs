using MediatR;
using Poliedro.Billing.Application.Destino.Dto;

namespace Poliedro.Billing.Application.Destino.Query;
public record GetAllActuatorsQuery: IRequest<IEnumerable<DestinoDto>>;