using Poliedro.Billing.Domain.Vehiculo.Ports;
using Poliedro.Billing.Domain.Vehiculo.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Vehiculo.Adapter;

public class VehiculoRepository(DataBaseContext _context) : IVehiculoRepository
{

    public async Task<IEnumerable<VehiculoEntity>> GetAllAsync()
    {
        return await _context.Vehiculo.ToListAsync();
    }

    public async Task<VehiculoEntity> GetById(int idvehiculo)
    {
        return await _context.Vehiculo.FirstAsync(x => x.idvehiculo == idvehiculo);
    }

    public async Task<bool> SaveAsync(VehiculoEntity vehiculo)
    {
          await _context.Vehiculo.AddAsync(vehiculo);
        return  await _context.SaveChangesAsync() > 0;
    }
}
