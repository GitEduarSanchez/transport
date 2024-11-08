using MediatR;
using Poliedro.Billing.Domain.TipoVehiculo.Entities.Ports;
using Poliedro.Billing.Domain.TipoVehiculo.Ports;

namespace Poliedro.Billing.Application.TipoVehiculo.Commands.Handle;

public class DeleteEntityCommandHandler(ITipoVehiculoRepository tipovehiculoRepository) : IRequestHandler<DeleteTipoVehiculoCommand, bool>
{
    public async Task<bool> Handle(DeleteTipoVehiculoCommand request, CancellationToken cancellationToken)
    {
        return await tipovehiculoRepository.DeleteAsync(request.Id);
    }
}
