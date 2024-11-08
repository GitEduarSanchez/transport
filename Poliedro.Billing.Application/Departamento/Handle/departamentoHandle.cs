using MediatR;
using Poliedro.Billing.Domain.departamento.Ports;
using Poliedro.Billing.Domain.departamento.Entities;
using Poliedro.Billing.Application.departamento.Commands;


namespace Poliedro.Billing.Application.departamento.Handle;

public class departamentoHandle(IdepartamentoRepository _departamentoRepository) : IRequestHandler<CreatedepartamentoCommand, bool>
{
    public async Task<bool> Handle(CreatedepartamentoCommand request, CancellationToken cancellationToken)
    {
        departamentoEntity departamento = new() { descripcion = request.descripcion, idpais =request.idpais };
        return await _departamentoRepository.SaveAsync(departamento); 
    }
    
}

