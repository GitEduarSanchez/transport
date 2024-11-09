using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.ControlViajeProducto.Entities;
using Poliedro.Billing.Domain.ControlViajeProducto.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.ControlViajeProducto.Adapter;

public class controlViajeProductoRepository(DataBaseContext _context) : IControlViajeProductoRepository
{

    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.ControlViajeProducto.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.ControlViajeProducto.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<IEnumerable<ControlViajeProductoEntity>> GetAllAsync()
    {
        return await _context.ControlViajeProducto.ToListAsync();
    }

    public async Task<ControlViajeProductoEntity> GetById(int Id)
    {
        return await _context.ControlViajeProducto.FirstAsync(x => x.idControlViajeProducto == Id);
    }

    public async Task<bool> SaveAsync(ControlViajeProductoEntity ControlViajeProducto)
    {
        await _context.ControlViajeProducto.AddAsync(ControlViajeProducto);
        return  await _context.SaveChangesAsync() > 0;
    }


 public async Task UpdateAsync(int Id, controlViajeProductoEntity controlViajeProducto)
    {
        var entity = await _context.ControlViajeProducto.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.idControlViaje = controlViajeProducto.idControlViaje;
        entity.idProducto = controlViajeProducto.idControlViaje;
        _context.ControlViajeProducto.Update(entity);
        await _context.SaveChangesAsync();
    }
}