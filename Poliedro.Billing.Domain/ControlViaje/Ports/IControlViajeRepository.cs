using Poliedro.Billing.Domain.ControlViaje.Entities;
using Poliedro.Billing.Domain.Estado.Request;

namespace Poliedro.Billing.Domain.ControlViaje.Entities.Ports;

public interface IControlViajeRepository
{
    Task<bool> SaveAsync(ControlViajeEntity controlViaje);
    Task<IEnumerable<ControlViajeEntity>> GetAllAsync();
    Task<ControlViajeEntity> GetById(int idControlViaje);
    Task<bool> DeleteAsync(int Id);
    Task UpdateAsync(int Id, ControlViajeEntity controlViaje);
}
