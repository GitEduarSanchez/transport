using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.ControlViaje.Entities;
using Poliedro.Billing.Domain.ControlViaje.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.ControlViaje.Adapter;

public class ControlViajeRepository(DataBaseContext _context) : IControlViajeRepository
{
    public async Task<IEnumerable<ControlViajeEntity>> GetAllAsync()
    {
        return await _context.ControlViaje.ToListAsync();
    }
       public async Task<ControlViajeEntity> GetById(int Id)
    {
        return await _context.ControlViaje.FirstAsync(x => x.idControlViaje== Id);
    }
    public async Task<bool> SaveAsync(ControlViajeEntity controlViaje)
    {
        await _context.ControlViaje.AddAsync(controlViaje);
        return  await _context.SaveChangesAsync() > 0;
    }
}
