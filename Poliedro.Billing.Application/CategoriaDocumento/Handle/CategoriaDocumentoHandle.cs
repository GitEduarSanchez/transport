using MediatR;
using Poliedro.Billing.Domain.CategoriaDocumento.Ports;
using Poliedro.Billing.Domain.CategoriaDocumento.Entities;
using Poliedro.Billing.Application.CategoriaDocumento.Commands;


namespace Poliedro.Billing.Application.CategoriaDocumento.Handle;

public class CategoriaDocumentoHandle(ICategoriaDocumentoRepository _CategoriaDocumentoRepository) : IRequestHandler<CreateCategoriaDocumentoCommand, bool>
{
    public async Task<bool> Handle(CreateCategoriaDocumentoCommand request, CancellationToken cancellationToken)
    {
        CategoriaDocumentoEntity CategoriaDocumento = new() { descripcion = request.descripcion};
        return await _CategoriaDocumentoRepository.SaveAsync(CategoriaDocumento); 
    }
    
}

