using MediatR;
using Poliedro.Billing.Domain.Origen.Entities;
using Poliedro.Billing.Domain.Origen.Entities.Ports;

namespace Poliedro.Billing.Application.Origen.Commands.Handle;

public class UpdateOrigenCommandHandler(IOrigenRepository _origenRepository) : IRequestHandler<UpdateOrigenCommand, Unit>
{
    public async Task<Unit> Handle(UpdateOrigenCommand request, CancellationToken cancellationToken)
    {
        var origen = await _origenRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        origen.descripcion = request.OrigenEntity.descripcion;
        await _origenRepository.UpdateAsync(request.Id, new OrigenEntity() { descripcion = origen.descripcion});
        return Unit.Value;
    }
}
