using MediatR;
using Poliedro.Billing.Application.categoria_documento.Dto;
using Poliedro.Billing.Domain.categoria_documento.Ports;

namespace Poliedro.Billing.Application.categoria_documento.Query;

public class GetByIdcategoria_documentoHandle(Icategoria_documentoRepository categoria_documentoRepository) : IRequestHandler<GetByIdcategoria_documentoQuery, categoria_documentoDto>
{
    public async Task<categoria_documentoDto> Handle(GetByIdcategoria_documentoQuery request, CancellationToken cancellationToken)
    {
        var getByIdcategoria_documento = await categoria_documentoRepository.GetById(request.Id);
        return new categoria_documentoDto(Id: getByIdcategoria_documento.Id, descripcion: getByIdcategoria_documento.descripcion);
    }
}
