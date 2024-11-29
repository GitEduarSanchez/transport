using Poliedro.Billing.Domain.Origen.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Origen.Entities.Ports;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Origen.Adapter;

public class OrigenRepository(DataBaseContext _context) : IOrigenRepository
{
     public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.Origen.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.Origen.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<IEnumerable<OrigenEntity>> GetAllAsync()
    {
        return await _context.Origen.ToListAsync();
    }

    public async Task<OrigenEntity> GetById(int Id)
    {
        return await _context.Origen.FirstAsync(x => x.Id == Id);
    }

    public Task<bool> SaveAsync(OrigenEntity origen)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int Id, OrigenEntity origen)
    {
        var entity = await _context.Origen.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.descripcion = origen.descripcion;
        _context.Origen.Update(entity);
        await _context.SaveChangesAsync();
    }
}
