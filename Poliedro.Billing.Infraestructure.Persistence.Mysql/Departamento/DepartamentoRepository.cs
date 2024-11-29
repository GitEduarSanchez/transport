using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.departamento.Entities;
using Poliedro.Billing.Domain.departamento.Entities.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.departamento.Adapter;

public class departamentoRepository(DataBaseContext _context) : IdepartamentoRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.departamento.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.departamento.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<departamentoEntity>> GetAllAsync()
    {
        return await _context.departamento.ToListAsync();
    }

    public async Task<departamentoEntity> GetById(int Id)
    {
        return await _context.departamento.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(departamentoEntity departamento)
    {
        await _context.departamento.AddAsync(departamento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateAsync(int Id, departamentoEntity departamento)
    {
        var entity = await _context.departamento.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.descripcion = departamento.descripcion;
        _context.departamento.Update(entity);
        await _context.SaveChangesAsync();
    }
}
