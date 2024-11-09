using MediatR;
using Poliedro.Billing.Application.TipoVehiculo.Dto;

namespace Poliedro.Billing.Application.TipoVehiculo.Commands.Query;

public record GetAllTipoVehiculoQuery : IRequest<IEnumerable<TipoVehiculoDto>>;

