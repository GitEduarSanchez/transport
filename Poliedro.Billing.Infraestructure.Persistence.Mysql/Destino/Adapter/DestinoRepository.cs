using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Destino.Entities;
using Poliedro.Billing.Domain.Destino.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Destino.Adapter;

public class DestinoRepository(DataBaseContext _context) : IDestinoRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.Destino.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.Destino.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<IEnumerable<DestinoEntity>> GetAllAsync()
    {
        return await _context.Destino.ToListAsync();
    }

    public async Task<DestinoEntity> GetById(int Id)
    {
        return await _context.Destino.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(DestinoEntity destino)
    {
        await _context.Destino.AddAsync(destino);
        return  await _context.SaveChangesAsync() > 0;
    }
    
    public async Task UpdateAsync(int Id, DestinoEntity destino)
    {
        var entity = await _context.Destino.FindAsync(Id) ??throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.Descripcion = destino.Descripcion;
        _context.Destino.Update(entity);
        await _context.SaveChangesAsync();
    }
}
