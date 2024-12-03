using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.pais.Entities;
using Poliedro.Billing.Domain.pais.Entities.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.pais.Adapter;

public class paisRepository(DataBaseContext _context) : IpaisRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.pais.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.pais.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

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

    public async Task UpdateAsync(int Id, paisEntity pais)
    {
        var entity = await _context.pais.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.Descripcion = pais.Descripcion;
        _context.pais.Update(entity);
        await _context.SaveChangesAsync();
    }
}
