using MediatR;
using Poliedro.Billing.Domain.departamento.Entities.Ports;

namespace Poliedro.Billing.Application.departamento.Commands.Handle;

public class DeleteEntityCommandHandler(IdepartamentoRepository departamentoRepository) : IRequestHandler<DeletedepartamentoCommand, bool>
{
    public async Task<bool> Handle(DeletedepartamentoCommand request, CancellationToken cancellationToken)
    {
        return await departamentoRepository.DeleteAsync(request.Id);
    }
}
