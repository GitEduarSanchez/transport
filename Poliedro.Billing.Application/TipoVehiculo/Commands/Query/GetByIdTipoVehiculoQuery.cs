using MediatR;
using Poliedro.Billing.Application.TipoVehiculo.Dto;

namespace Poliedro.Billing.Application.TipoVehiculo.Query;

public record GetByIdTipoVehiculoQuery(int Id): IRequest<TipoVehiculoDto>;

