using MediatR;
using Poliedro.Billing.Application.Vehiculo.Dto;
namespace Poliedro.Billing.Application.Vehiculo.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<VehiculoDto>>;

