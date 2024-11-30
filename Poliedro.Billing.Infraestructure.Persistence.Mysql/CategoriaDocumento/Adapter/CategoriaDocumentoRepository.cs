using Poliedro.Billing.Domain.CategoriaDocumento.Ports;
using Poliedro.Billing.Domain.CategoriaDocumento.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.CategoriaDocumento;

public class CategoriaDocumentoRepository(DataBaseContext _context) : ICategoriaDocumentoRepository
{

    public async Task<IEnumerable<CategoriaDocumentoEntity>> GetAllAsync()
    {
        return await _context.CategoriaDocumento.ToListAsync();
    }

    public async Task<CategoriaDocumentoEntity> GetById(int Id)
    {
        return await _context.CategoriaDocumento.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(CategoriaDocumentoEntity CategoriaDocumento)
    {
        await _context.CategoriaDocumento.AddAsync(CategoriaDocumento);
        return await _context.SaveChangesAsync() > 0;
    }
}
