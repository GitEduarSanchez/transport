using MediatR;
using Poliedro.Billing.Application.unidad_medida.Dto;

namespace Poliedro.Billing.Application.unidad_medida.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<unidad_medidaDto>>;

