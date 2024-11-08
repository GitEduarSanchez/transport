using MediatR;
using Poliedro.Billing.Application.departamento.Dto;
using Poliedro.Billing.Domain.departamento.Ports;

namespace Poliedro.Billing.Application.departamento.Query;

public class GetByIddepartamentoHandle(IdepartamentoRepository departamentoRepository) : IRequestHandler<GetByIddepartamentoQuery, departamentoDto>
{
    public async Task<departamentoDto> Handle(GetByIddepartamentoQuery request, CancellationToken cancellationToken)
    {
        var getByIddepartamento = await departamentoRepository.GetById(request.Id);
        return new departamentoDto(Id: getByIddepartamento.Id, descripcion: getByIddepartamento.descripcion,idpais: getByIddepartamento.idpais);
    }
}
