using Poliedro.Billing.Domain.Ciudad.Ports;
using Poliedro.Billing.Domain.Ciudad.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Ciudad.Adapter;

public class CiudadRepository(DataBaseContext _context) : ICiudadRepository
{

    public async Task<IEnumerable<CiudadEntity>> GetAllAsync()
    {
        return await _context.Ciudad.ToListAsync();
    }

    public async Task<CiudadEntity> GetById(int Id)
    {
        return await _context.Ciudad.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(CiudadEntity Ciudad)
    {
          await _context.Ciudad.AddAsync(Ciudad);
        return  await _context.SaveChangesAsync() > 0;
    }
}
