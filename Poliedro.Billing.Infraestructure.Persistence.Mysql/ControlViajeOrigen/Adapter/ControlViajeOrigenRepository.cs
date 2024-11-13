using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.ControlViajeOrigen.Entities;
using Poliedro.Billing.Domain.ControlViajeOrigen.Entities.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.ControlViajeOrigen.Adapter;

public class ControlViajeOrigenRepository(DataBaseContext _context) : IControlViajeOrigenRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.ControlViajeOrigen.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.ControlViajeOrigen.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<ControlViajeOrigenEntity>> GetAllAsync()
    {
        return await _context.ControlViajeOrigen.ToListAsync();
    }

    public async Task<ControlViajeOrigenEntity> GetById(int Id)
    {
        return await _context.ControlViajeOrigen.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(ControlViajeOrigenEntity controlviajeorigen)
    {
        await _context.ControlViajeOrigen.AddAsync(controlviajeorigen);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateAsync(int Id, ControlViajeOrigenEntity controlviajeorigen)
    {
        var entity = await _context.ControlViajeOrigen.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.Descripcion = controlviajeorigen.Descripcion;
        _context.ControlViajeOrigen.Update(entity);
        await _context.SaveChangesAsync();
    }
}
