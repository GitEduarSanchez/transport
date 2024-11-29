using Poliedro.Billing.Domain.unidad_medida.Entities;
using Poliedro.Billing.Domain.unidad_medida.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.unidad_medida.Adapter;

public class unidad_medidaRepository(DataBaseContext _context) : Iunidad_medidaRepository
{
    public async Task<IEnumerable<unidad_medidaEntity>> GetAllAsync()
    {
        return await _context.unidad_medida.ToListAsync();
    }

    public async Task<unidad_medidaEntity> GetById(int Id)
    {
        return await _context.unidad_medida.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(unidad_medidaEntity unidad_medida)
    {
        await _context.unidad_medida.AddAsync(unidad_medida);
        return  await _context.SaveChangesAsync() > 0;
    }
}
