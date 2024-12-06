using MediatR;
using Poliedro.Billing.Application.Vehhiculo.Query;
using Poliedro.Billing.Application.Vehiculo.Dto;
using Poliedro.Billing.Domain.Vehiculo.Ports;

namespace Poliedro.Billing.Application.Vehiculo.Query;

public class GetByidvehiculoHandle(IVehiculoRepository VehiculoRepository) : IRequestHandler<GetByidvehiculoQuery, VehiculoDto>
{
    public async Task<VehiculoDto> Handle(GetByidvehiculoQuery request, CancellationToken cancellationToken)
    {
        var getByidvehiculo = await VehiculoRepository.GetById(request.idvehiculo);
        return new VehiculoDto(idvehiculo: getByidvehiculo.idvehiculo,placa: getByidvehiculo.placa,idmarca: getByidvehiculo.idmarca,idtipovehiculo: getByidvehiculo.idtipovehiculo  );
        
     
    }
}
