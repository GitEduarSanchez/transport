using MediatR;
using Poliedro.Billing.Domain.pais.Entities;
using Poliedro.Billing.Domain.pais.Entities.Ports;

namespace Poliedro.Billing.Application.pais.Commands.Handle;

public class UpdatepaisCommandHandler(IpaisRepository _paisRepository) : IRequestHandler<UpdatepaisCommand, Unit>
{
    public async Task<Unit> Handle(UpdatepaisCommand request, CancellationToken cancellationToken)
    {
        var pais = await _paisRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        pais.Descripcion = request.paisEntity.Descripcion;
        await _paisRepository.UpdateAsync(request.Id, new paisEntity() { Descripcion = pais.Descripcion});
        return Unit.Value;
    }
}
