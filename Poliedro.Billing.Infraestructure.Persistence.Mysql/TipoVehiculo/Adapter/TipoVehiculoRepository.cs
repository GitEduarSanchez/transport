using Poliedro.Billing.Domain.TipoVehiculo.Entities;
using Poliedro.Billing.Domain.TipoVehiculo.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.TipoVehiculo.Adapter;

public class TipoVehiculoRepository(DataBaseContext _context) : ITipoVehiculoRepository
{
        var entity = await _context.TipoVehiculo.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.TipoVehiculo.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<TipoVehiculoEntity>> GetAllAsync()
    {
        return await _context.TipoVehiculo.ToListAsync();
    }

    public async Task<TipoVehiculoEntity> GetById(int Id)
    {
        return await _context.TipoVehiculo.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(TipoVehiculoEntity tipovehiculo)
    {
        await _context.TipoVehiculo.AddAsync(tipovehiculo);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateAsync(int Id, TipoVehiculoEntity tipovehiculo)
    {
        var entity = await _context.TipoVehiculo.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.descripcion = tipovehiculo.descripcion;
        _context.TipoVehiculo.Update(entity);
        await _context.SaveChangesAsync();
    }
}
