using MediatR;
using Poliedro.Billing.Domain.VehiculoTrailerDestino.Ports;
using Poliedro.Billing.Domain.VehiculoTrailerDestino.Entities;
using Poliedro.Billing.Application.VehiculoTrailerDestino.Commands.CreateServerCommand;


namespace Poliedro.Billing.Application.VehiculoTrailerDestino.Handle;

public class VehiculoTrailerDestinoHandle(IVehiculoTrailerDestinoRepository _VehiculoTrailerDestinoRepository) : IRequestHandler<CreateVehiculoTrailerDestinoCommand, bool>
{
    public async Task<bool> Handle(CreateVehiculoTrailerDestinoCommand request, CancellationToken cancellationToken)
    {
        VehiculoTrailerDestinoEntity VehiculoTrailerDestino = new() { dvehiculotrailer= request.dvehiculotrailer,iddestino= request.iddestino,idcuidad= request.idcuidad};
        return await _VehiculoTrailerDestinoRepository.SaveAsync(VehiculoTrailerDestino); 
    }
    
}

