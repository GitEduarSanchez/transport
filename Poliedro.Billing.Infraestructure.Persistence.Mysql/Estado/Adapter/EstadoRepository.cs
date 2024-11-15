using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Estado.Entities;
using Poliedro.Billing.Domain.Estado.Entities.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Estado.Adapter;

public class EstadoRepository(DataBaseContext _context) : IEstadoRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.Estado.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.Estado.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<EstadoEntity>> GetAllAsync()
    {
        return await _context.Estado.ToListAsync();
    }

    public async Task<EstadoEntity> GetById(int Id)
    {
        return await _context.Estado.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(EstadoEntity estado)
    {
        await _context.Estado.AddAsync(estado);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateAsync(int Id, EstadoEntity estado)
    {
        var entity = await _context.Estado.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.Descripcion = estado.Descripcion;
        _context.Estado.Update(entity);
        await _context.SaveChangesAsync();
    }
}
