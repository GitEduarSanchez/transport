using MediatR;
using Poliedro.Billing.Domain.pais.Entities;
using Poliedro.Billing.Application.pais.Commands;
using Poliedro.Billing.Domain.pais.Entities.Ports;


namespace Poliedro.Billing.Application.pais.Handle;

public class paisHandle(IpaisRepository _paisRepository) : IRequestHandler<CreatepaisCommand, bool>
{
    public async Task<bool> Handle(CreatepaisCommand request, CancellationToken cancellationToken)
    {
        paisEntity pais = new() { Descripcion = request.descripcion};
        return await _paisRepository.SaveAsync(pais); 
    }
    
}

