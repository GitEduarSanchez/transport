using Poliedro.Billing.Domain.Ciudad.Ports;
using Poliedro.Billing.Domain.View_Ciudad.Entities;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;
using Microsoft.EntityFrameworkCore;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.Ciudad.Adapter;

public class View_CiudadRepository(DataBaseContext _context) : IView_CiudadRepository
{

    public async Task<IEnumerable<View_CiudadEntity>> GetAllAsync()
    {
        return await _context.View_Ciudad.ToListAsync();
    }

    public async Task<bool> SaveAsync(View_CiudadEntity Ciudad)
    {
          await _context.View_Ciudad.AddAsync(Ciudad);
        return  await _context.SaveChangesAsync() > 0;
    }
}
