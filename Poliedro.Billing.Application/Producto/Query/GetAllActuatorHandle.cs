using MediatR;
using Poliedro.Billing.Application.Producto.Dto;
using Poliedro.Billing.Domain.Producto.Ports;

namespace Poliedro.Billing.Application.Producto.Query;

public class GetAllActuatorHandle(IProductoRepository _productoRepository) : IRequestHandler<GetAllActuatorsQuery, IEnumerable<ProductoDto>>
{
    public async Task<IEnumerable<ProductoDto>> Handle(GetAllActuatorsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _productoRepository.GetAllAsync();
        return entities.Select(producto => new ProductoDto
        (
            Id: producto.Id,
            descripcion: producto.descripcion,
            idunidad_medida: producto.idunidad_medida
        ));
    }
}
