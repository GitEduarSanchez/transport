using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Concepto.Entities;
using Poliedro.Billing.Domain.Concepto.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Concepto.Adapter;

public class ConceptoRepository(DataBaseContext _context) : IConceptoRepository
{

    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.Concepto.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.Concepto.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<IEnumerable<ConceptoEntity>> GetAllAsync()
    {
        return await _context.Concepto.ToListAsync();
    }

    public async Task<ConceptoEntity> GetById(int Id)
    {
        return await _context.Concepto.FirstAsync(x => x.idConcepto == Id);
    }

    public async Task<bool> SaveAsync(ConceptoEntity concepto)
    {
        await _context.Concepto.AddAsync(concepto);
        return  await _context.SaveChangesAsync() > 0;
    }
    
    public async Task UpdateAsync(int Id, ConceptoEntity concepto)
    {
        var entity = await _context.Concepto.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.descripcion = concepto.descripcion;
        _context.Concepto.Update(entity);
        await _context.SaveChangesAsync();
    }
}
