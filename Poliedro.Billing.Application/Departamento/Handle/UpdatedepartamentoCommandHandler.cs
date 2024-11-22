using MediatR;
using Poliedro.Billing.Domain.departamento.Entities;
using Poliedro.Billing.Domain.departamento.Entities.Ports;

namespace Poliedro.Billing.Application.departamento.Commands.Handle;

public class UpdatedepartamentoCommandHandler(IdepartamentoRepository _departamentoRepository) : IRequestHandler<UpdatedepartamentoCommand, Unit>
{
    public async Task<Unit> Handle(UpdatedepartamentoCommand request, CancellationToken cancellationToken)
    {
        var departamento = await _departamentoRepository.GetById(request.Id) ?? throw new Exception("No Found.");
        departamento.descripcion = request.departamentoEntity.Descripcion;
        await _departamentoRepository.UpdateAsync(request.Id, new departamentoEntity() { descripcion = departamento.descripcion});
        return Unit.Value;
    }
}
