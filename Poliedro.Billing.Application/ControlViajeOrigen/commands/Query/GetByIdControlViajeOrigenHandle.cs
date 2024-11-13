using MediatR;
using Poliedro.Billing.Application.ControlViajeOrigen.Commands.Dto;
using Poliedro.Billing.Domain.ControlViajeOrigen.Entities.Ports;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands.Query;

public class GetByIdControlViajeOrigenHandle(IControlViajeOrigenRepository controlviajeorigenRepository) : IRequestHandler<GetByIdControlViajeOrigenQuery, ControlViajeOrigenDto>
{
    public async Task<ControlViajeOrigenDto> Handle(GetByIdControlViajeOrigenQuery request, CancellationToken cancellationToken)
    {
        var getByIdControlViajeOrigen = await controlviajeorigenRepository.GetById(request.Id);
        return new ControlViajeOrigenDto(Id: getByIdControlViajeOrigen.Id, Descripcion: getByIdControlViajeOrigen.Descripcion);
    }
}
