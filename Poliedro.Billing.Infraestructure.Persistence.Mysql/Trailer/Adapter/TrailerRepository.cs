using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Trailer.Entities;
using Poliedro.Billing.Domain.Trailer.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Trailer.Adapter;

public class TrailerRepository(DataBaseContext _context) : ITrailerRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.Trailer.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.Trailer.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<TrailerEntity>> GetAllAsync()
    {
        return await _context.Trailer.ToListAsync();
    }

    public async Task<TrailerEntity> GetById(int Id)
    {
        return await _context.Trailer.FirstAsync(x => x.idtrailer == Id);
    }

    public async Task<bool> SaveAsync(TrailerEntity trailer)
    {
        await _context.Trailer.AddAsync(trailer);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateAsync(int Id, TrailerEntity trailer)
    {
        var entity = await _context.Trailer.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.descripcion = trailer.descripcion;
        _context.Trailer.Update(entity);
        await _context.SaveChangesAsync();
    }
}