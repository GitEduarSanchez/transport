using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Conductor.Entities;
using Poliedro.Billing.Domain.Conductor.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Conductor.Adapter;

public class ConductorRepository(DataBaseContext _context) : IConductorRepository
{
    public async Task<IEnumerable<ConductorEntity>> GetAllAsync()
    {
        return await _context.Conductor.ToListAsync();
    }

    public Task<ConductorEntity> GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAsync(ConductorEntity conductor)
    {
        await _context.Conductor.AddAsync(conductor);
        return  await _context.SaveChangesAsync() > 0;
    }
}
