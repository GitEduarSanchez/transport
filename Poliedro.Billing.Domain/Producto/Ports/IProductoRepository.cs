using Poliedro.Billing.Domain.Producto.Entities;
using Poliedro.Billing.Domain.Producto.Request;

namespace Poliedro.Billing.Domain.Producto.Entities.Ports;

public interface IProductoRepository
{
    Task<bool> SaveAsync(ProductoEntity Producto);
    Task<IEnumerable<ProductoEntity>> GetAllAsync();
    Task<ProductoEntity> GetById(int Id);
    Task<bool> DeleteAsync(int Id);
    Task UpdateAsync(int Id, ProductoEntity Producto);
}
