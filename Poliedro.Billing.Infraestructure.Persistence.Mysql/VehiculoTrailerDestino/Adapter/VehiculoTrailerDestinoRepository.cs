using Poliedro.Billing.Domain.VehiculoTrailerDestino.Ports;
using Poliedro.Billing.Domain.VehiculoTrailerDestino.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.VehiculoTrailerDestino.Adapter;

public class VehiculoTrailerDestinoRepository(DataBaseContext _context) : IVehiculoTrailerDestinoRepository
{

    public async Task<IEnumerable<VehiculoTrailerDestinoEntity>> GetAllAsync()
    {
        return await _context.VehiculoTrailerDestino.ToListAsync();
    }

    public async Task<VehiculoTrailerDestinoEntity> GetById(int Id)
    {
        return await _context.VehiculoTrailerDestino.FirstAsync(x => x.Id == Id);
    }

    public async Task<bool> SaveAsync(VehiculoTrailerDestinoEntity VehiculoTrailerDestino)
    {
          await _context.VehiculoTrailerDestino.AddAsync(VehiculoTrailerDestino);
        return  await _context.SaveChangesAsync() > 0;
    }
}
