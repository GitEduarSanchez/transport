using Poliedro.Billing.Domain.TipoVehiculo.Entities;
using Poliedro.Billing.Domain.TipoVehiculo.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.TipoVehiculo.Adapter;

public class TipoVehiculoRepository(DataBaseContext _context) : ITipoVehiculoRepository
{
    public async Task<IEnumerable<TipoVehiculoEntity>> GetAllAsync()
    {
        return await _context.TipoVehiculo.ToListAsync();
    }

    public async Task<TipoVehiculoEntity> GetById(int Id)
    {
        return await _context.TipoVehiculo.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(TipoVehiculoEntity TipoVehiculo)
    {
        await _context.TipoVehiculo.AddAsync(TipoVehiculo);
        return  await _context.SaveChangesAsync() > 0;
    }
}
