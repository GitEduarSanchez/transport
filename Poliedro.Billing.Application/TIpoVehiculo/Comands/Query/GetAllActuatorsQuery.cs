using MediatR;
using Poliedro.Billing.Application.TipoVehiculo.Dto;
namespace Poliedro.Billing.Application.TipoVehiculo.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<TipoVehiculoDto>>;

