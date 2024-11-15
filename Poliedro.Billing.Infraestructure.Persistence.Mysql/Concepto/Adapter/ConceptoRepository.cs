using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.Concepto.Entities;
using Poliedro.Billing.Domain.Concepto.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Concepto.Adapter;

public class ConceptoRepository(DataBaseContext _context) : IConceptoRepository
{

    public async Task<IEnumerable<ConceptoEntity>> GetAllAsync()
    {
        return await _context.Concepto.ToListAsync();
    }

    public async Task<ConceptoEntity> GetById(int Id)
    {
        return await _context.Concepto.FirstAsync(x => x.IdConcepto == Id);
    }

    public async Task<bool> SaveAsync(ConceptoEntity concepto)
    {
        await _context.Concepto.AddAsync(concepto);
        return  await _context.SaveChangesAsync() > 0;
    }
}
