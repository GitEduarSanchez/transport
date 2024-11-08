using Poliedro.Billing.Domain.categoria_documento.Ports;
using Poliedro.Billing.Domain.categoria_documento.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.categoria_documento;

public class categoria_documentoRepository(DataBaseContext _context) : Icategoria_documentoRepository
{

    public async Task<IEnumerable<categoria_documentoEntity>> GetAllAsync()
    {
        return await _context.categoria_documento.ToListAsync();
    }

    public async Task<categoria_documentoEntity> GetById(int Id)
    {
        return await _context.categoria_documento.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(categoria_documentoEntity categoria_Documento)
    {
        await _context.categoria_documento.AddAsync(categoria_Documento);
        return await _context.SaveChangesAsync() > 0;
    }
}
