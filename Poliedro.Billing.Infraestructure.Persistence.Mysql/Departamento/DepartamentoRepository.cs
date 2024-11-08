using Poliedro.Billing.Domain.departamento.Ports;
using Poliedro.Billing.Domain.departamento.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.departamento;

public class departamentoRepository(DataBaseContext _context) : IdepartamentoRepository
{

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
}
