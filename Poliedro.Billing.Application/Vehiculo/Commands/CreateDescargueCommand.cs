using MediatR;

namespace Poliedro.Billing.Application.Vehiculo.Commands;

public record CreateVehiculoCommand(int idvehiculo, string placa,int idmarca,int idtipovehiculo) : IRequest<bool>;
