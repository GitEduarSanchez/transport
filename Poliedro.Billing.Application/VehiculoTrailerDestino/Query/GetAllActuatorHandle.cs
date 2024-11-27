using MediatR;
using Poliedro.Billing.Application.VehiculoTrailerDestino.Dto;
using Poliedro.Billing.Domain.VehiculoTrailerDestino.Ports;

namespace Poliedro.Billing.Application.VehiculoTrailerDestino.Query;

public class GetAllActuatorHandle(IVehiculoTrailerDestinoRepository  _VehiculoTrailerDestinoRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<VehiculoTrailerDestinoDto>>
{
    public async Task<IEnumerable<VehiculoTrailerDestinoDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _VehiculoTrailerDestinoRepository.GetAllAsync();
        return entities.Select(VehiculoTrailerDestino => new VehiculoTrailerDestinoDto
        (
            Id: VehiculoTrailerDestino.Id,
            dvehiculotrailer: VehiculoTrailerDestino.dvehiculotrailer,
            iddestino: VehiculoTrailerDestino.iddestino,
            idcuidad: VehiculoTrailerDestino.idcuidad
           
        ));
    }
}
