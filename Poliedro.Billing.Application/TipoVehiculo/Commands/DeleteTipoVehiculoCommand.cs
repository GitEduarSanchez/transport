using MediatR;

namespace Poliedro.Billing.Application.TipoVehiculo.Commands;

public record DeleteTipoVehiculoCommand(int Id) : IRequest<bool>;

