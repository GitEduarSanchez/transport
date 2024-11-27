using MediatR;
using Poliedro.Billing.Domain.categoria_documento.Ports;
using Poliedro.Billing.Domain.categoria_documento.Entities;
using Poliedro.Billing.Application.categoria_documento.Commands;


namespace Poliedro.Billing.Application.categoria_documento.Handle;

public class categoria_documentoHandle(Icategoria_documentoRepository _categoria_documentoRepository) : IRequestHandler<Createcategoria_documentoCommand, bool>
{
    public async Task<bool> Handle(Createcategoria_documentoCommand request, CancellationToken cancellationToken)
    {
        categoria_documentoEntity categoria_documento = new() { descripcion = request.descripcion};
        return await _categoria_documentoRepository.SaveAsync(categoria_documento); 
    }
    
}

