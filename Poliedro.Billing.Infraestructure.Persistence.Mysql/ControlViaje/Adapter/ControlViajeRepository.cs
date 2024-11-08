using Microsoft.EntityFrameworkCore;
using Poliedro.Billing.Domain.ControlViaje.Entities;
using Poliedro.Billing.Domain.ControlViaje.Entities.Ports;
using Poliedro.Billing.Infraestructure.Persistence.Mysql.Context;

namespace Poliedro.Billing.Infraestructure.Persistence.Mysql.ControlViaje.Adapter;

public class ControlViajeRepository(DataBaseContext _context) : IControlViajeRepository
{
    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _context.ControlViaje.FindAsync(Id);
        if (entity == null)
        {
            return false;
        }
        _context.ControlViaje.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<ControlViajeEntity>> GetAllAsync()
    {
        return await _context.ControlViaje.ToListAsync();
    }

    public async Task<ControlViajeEntity> GetById(int Id)
    {
        return await _context.ControlViaje.FirstAsync(x => x.idControlViaje == Id);
    }

    public async Task<bool> SaveAsync(ControlViajeEntity controlviaje)
    {
        await _context.ControlViaje.AddAsync(controlviaje);
        return await _context.SaveChangesAsync() > 0;
    }

       public async Task UpdateAsync(int Id, ControlViajeEntity controlviaje)
    {
        var entity = await _context.ControlViaje.FindAsync(Id) ?? throw new KeyNotFoundException($"Entity with Id {Id} not found.");
        entity.guia = controlviaje.guia;
        entity.fecha = controlviaje.fecha;
        entity.idVehiculoTrailer = controlviaje.idVehiculoTrailer;
        _context.ControlViaje.Update(entity);
        await _context.SaveChangesAsync();
    }

      }
    