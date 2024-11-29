using MediatR;
using Poliedro.Billing.Application.unidad_medida.Dto;

namespace Poliedro.Billing.Application.unidad_medida.Query;

public record GetByIdunidad_medidaQuery(int Id): IRequest<unidad_medidaDto>;

