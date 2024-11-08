using MediatR;

namespace Poliedro.Billing.Application.TipoVehiculo.Commands.CreateServerCommand;

public record CreateTipoVehiculoCommand(string Descripcion) : IRequest<bool>;
