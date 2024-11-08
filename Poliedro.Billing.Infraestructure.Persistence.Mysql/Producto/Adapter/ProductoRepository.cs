using Poliedro.Billing.Domain.Producto.Entities;
using Poliedro.Billing.Domain.Producto.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Producto.Adapter;

public class ProductoRepository(DataBaseContext _context) : IProductoRepository
{
    public async Task<IEnumerable<ProductoEntity>> GetAllAsync()
    {
        return await _context.Producto.ToListAsync();
    }

    public async Task<ProductoEntity> GetById(int Id)
    {
        return await _context.Producto.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(ProductoEntity Producto)
    {
        await _context.Producto.AddAsync(Producto);
        return  await _context.SaveChangesAsync() > 0;
    }
}
