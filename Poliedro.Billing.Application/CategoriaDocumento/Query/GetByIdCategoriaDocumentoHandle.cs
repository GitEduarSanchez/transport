using MediatR;
using Poliedro.Billing.Application.CategoriaDocumento.Dto;
using Poliedro.Billing.Domain.CategoriaDocumento.Ports;

namespace Poliedro.Billing.Application.CategoriaDocumento.Query;

public class GetByIdCategoriaDocumentoHandle(ICategoriaDocumentoRepository CategoriaDocumentoRepository) : IRequestHandler<GetByIdCategoriaDocumentoQuery, CategoriaDocumentoDto>
{
    public async Task<CategoriaDocumentoDto> Handle(GetByIdCategoriaDocumentoQuery request, CancellationToken cancellationToken)
    {
        var getByIdCategoriaDocumento = await CategoriaDocumentoRepository.GetById(request.Id);
        return new CategoriaDocumentoDto(Id: getByIdCategoriaDocumento.Id, descripcion: getByIdCategoriaDocumento.descripcion);
    }
}
