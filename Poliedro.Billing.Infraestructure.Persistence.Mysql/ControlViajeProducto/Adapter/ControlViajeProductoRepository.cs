using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.ControlViajeProducto.Entities;
using Poliedro.Billing.Domain.ControlViajeProducto.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.ControlViajeProducto.Adapter;

public class ControlViajeProductoRepository(DataBaseContext _context) : IControlViajeProductoRepository
{
    public async Task<IEnumerable<ControlViajeProductoEntity>> GetAllAsync()
    {
        return await _context.ControlViajeProducto.ToListAsync();
    }

    public async Task<ControlViajeProductoEntity> GetById(int Id)
    {
        return await _context.ControlViajeProducto.FirstAsync(x => x.idControlViajeProducto == Id);
    }

    public async Task<bool> SaveAsync(ControlViajeProductoEntity ControlViajeProducto)
    {
        await _context.ControlViajeProducto.AddAsync(ControlViajeProducto);
        return  await _context.SaveChangesAsync() > 0;
    }
}
