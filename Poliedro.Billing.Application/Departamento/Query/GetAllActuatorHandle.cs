using MediatR;
using Poliedro.Billing.Application.departamento.Dto;
using Poliedro.Billing.Domain.departamento.Ports;

namespace Poliedro.Billing.Application.departamento.Query;

public class GetAllActuatorHandle(IdepartamentoRepository _departamentoRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<departamentoDto>>
{
    public async Task<IEnumerable<departamentoDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _departamentoRepository.GetAllAsync();
        return entities.Select(departamento => new departamentoDto
        (
            Id: departamento.Id,
            descripcion: departamento.descripcion,
            idpais: departamento.idpais
        ));
    }
}
