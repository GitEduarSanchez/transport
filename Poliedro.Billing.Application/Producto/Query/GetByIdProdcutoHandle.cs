using MediatR;
using Poliedro.Billing.Application.Producto.Dto;
using Poliedro.Billing.Domain.Producto.Ports;

namespace Poliedro.Billing.Application.Producto.Query;

public class GetByIdproductoHandle(IProductoRepository productoRepository) : IRequestHandler<GetByIdProductoQuery, ProductoDto>
{
    public async Task<ProductoDto> Handle(GetByIdProductoQuery request, CancellationToken cancellationToken)
    {
        var getByIdProducto = await productoRepository.GetById(request.Id);
        return new ProductoDto(Id: getByIdProducto.Id, descripcion: getByIdProducto.descripcion, idunidad_medida:getByIdProducto.idunidad_medida);
    }
}
