using MediatR;
using Poliedro.Billing.Domain.TipoVehiculo.Request;

namespace Poliedro.Billing.Application.TipoVehiculo.Commands;

public record UpdateTipoVehiculoCommand(int Id, TipoVehiculoRequest TipoVehiculoEntity) : IRequest<Unit>;

