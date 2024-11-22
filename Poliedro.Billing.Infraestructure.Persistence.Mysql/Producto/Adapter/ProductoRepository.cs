using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Producto.Entities;
using Poliedro.Billing.Domain.Producto.Entities.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Producto.Adapter;

public class ProductoRepository(DataBaseContext _context) : IProductoRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.Producto.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.Producto.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

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
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateAsync(int Id, ProductoEntity Producto)
    {
        var entity = await _context.Producto.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.descripcion = Producto.descripcion;
        _context.Producto.Update(entity);
        await _context.SaveChangesAsync();
    }
}
