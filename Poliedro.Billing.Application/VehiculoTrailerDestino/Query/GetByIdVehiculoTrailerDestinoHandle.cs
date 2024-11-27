using MediatR;
using Poliedro.Billing.Application.VehiculoTrailerDestino.Dto;
using Poliedro.Billing.Domain.VehiculoTrailerDestino.Ports;

namespace Poliedro.Billing.Application.VehiculoTrailerDestino.Query;

public class GetByIdVehiculoTrailerDestinoHandle(IVehiculoTrailerDestinoRepository VehiculoTrailerDestinoRepository) : IRequestHandler<GetByIdVehiculoTrailerDestinoQuery, VehiculoTrailerDestinoDto>
{
    public async Task<VehiculoTrailerDestinoDto> Handle(GetByIdVehiculoTrailerDestinoQuery request, CancellationToken cancellationToken)
    {
        var getByIdVehiculoTrailerDestino = await VehiculoTrailerDestinoRepository.GetById(request.VehiculoTrailerDestino);
        return new VehiculoTrailerDestinoDto(VehiculoTrailerDestino: getByIdVehiculoTrailerDestino.VehiculoTrailerDestino, dvehiculotrailer: getByIdVehiculoTrailerDestino.dvehiculotrailer, iddestino: getByIdVehiculoTrailerDestino.iddestino, idcuidad: getByIdVehiculoTrailerDestino.idcuidad);
    }
}
