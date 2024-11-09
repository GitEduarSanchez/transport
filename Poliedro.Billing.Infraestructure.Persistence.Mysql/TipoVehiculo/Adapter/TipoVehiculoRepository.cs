using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.TipoVehiculo.Entities;
using Poliedro.Billing.Domain.TipoVehiculo.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.TipoVehiculo.Adapter;

public class TipoVehiculoRepository(DataBaseContext _context) : ITipoVehiculoRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.Tipovehiculo.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.Tipovehiculo.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<TipoVehiculoEntity>> GetAllAsync()
    {
        return await _context.Tipovehiculo.ToListAsync();
    }

    public async Task<TipoVehiculoEntity> GetById(int Id)
    {
        return await _context.Tipovehiculo.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(TipoVehiculoEntity tipovehiculo)
    {
        await _context.Tipovehiculo.AddAsync(tipovehiculo);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateAsync(int Id, TipoVehiculoEntity tipovehiculo)
    {
        var entity = await _context.Tipovehiculo.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.descripcion = tipovehiculo.descripcion;
        _context.Tipovehiculo.Update(entity);
        await _context.SaveChangesAsync();
    }
}
