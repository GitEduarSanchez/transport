using MediatR;
using Poliedro.Billing.Application.unidad_medida.commands;
using Poliedro.Billing.Domain.unidad_medida.Entities;
using Poliedro.Billing.Domain.unidad_medida.Ports;

namespace Poliedro.Billing.Application.unidad_medida.Handle;

public class unidad_medidaHandle(Iunidad_medidaRepository _unidad_medidaRepository) : IRequestHandler<Createunidad_medidaCommand, bool>
{
    public async Task<bool> Handle(Createunidad_medidaCommand request, CancellationToken cancellationToken)
    {
        unidad_medidaEntity unidad_medida = new() { descripcion= request.descripcion};
        return await _unidad_medidaRepository.SaveAsync(unidad_medida);
    }
}
