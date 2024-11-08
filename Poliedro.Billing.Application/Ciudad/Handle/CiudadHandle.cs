using MediatR;
using Poliedro.Billing.Domain.Ciudad.Ports;
using Poliedro.Billing.Domain.Ciudad.Entities;
using Poliedro.Billing.Application.Ciudad.Commands.CreateServerCommand;


namespace Poliedro.Billing.Application.Ciudad.Handle;

public class CiudadHandle(ICiudadRepository _ciudadRepository) : IRequestHandler<CreateCiudadCommand, bool>
{
    public async Task<bool> Handle(CreateCiudadCommand request, CancellationToken cancellationToken)
    {
        CiudadEntity ciudad = new() { Descripcion = request.descripcion, Iddepartamento=request.iddepartamento };
        return await _ciudadRepository.SaveAsync(ciudad); 
    }
    
}

