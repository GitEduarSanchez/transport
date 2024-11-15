using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.controlviaje_origen.Entities;
using Poliedro.Billing.Domain.controlviaje_origen.Entities.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.controlviaje_origen.Adapter;

public class controlviaje_origenRepository(DataBaseContext _context) : Icontrolviaje_origenRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.controlviaje_origen.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.controlviaje_origen.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<controlviaje_origenEntity>> GetAllAsync()
    {
        return await _context.controlviaje_origen.ToListAsync();
    }

    public async Task<controlviaje_origenEntity> GetById(int Id)
    {
        return await _context.controlviaje_origen.FirstAsync(x => x.idcontrolviaje_origen == Id);
    }

    public async Task<bool> SaveAsync(controlviaje_origenEntity controlviaje_origen)
    {
        await _context.controlviaje_origen.AddAsync(controlviaje_origen);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateAsync(int Id, controlviaje_origenEntity controlviaje_origen)
    {
        var entity = await _context.controlviaje_origen.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.idcontrolviaje_origen = controlviaje_origen.idcontrolviaje_origen;
        entity.idcontrolviaje = controlviaje_origen.idcontrolviaje;
        entity.idciudad = controlviaje_origen.idciudad;
        entity.idorigen = controlviaje_origen.idorigen;
        _context.controlviaje_origen.Update(entity);
        await _context.SaveChangesAsync();
    }
}
