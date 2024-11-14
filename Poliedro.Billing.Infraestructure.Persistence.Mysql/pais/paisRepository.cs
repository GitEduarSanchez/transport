using Poliedro.Billing.Domain.pais.Ports;
using Poliedro.Billing.Domain.pais.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.pais;

public class paisRepository(DataBaseContext _context) : IpaisRepository
{

    public async Task<IEnumerable<paisEntity>> GetAllAsync()
    {
        return await _context.pais.ToListAsync();
    }

    public async Task<paisEntity> GetById(int Id)
    {
        return await _context.pais.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(paisEntity pais)
    {
        await _context.pais.AddAsync(pais);
        return await _context.SaveChangesAsync() > 0;
    }
}
