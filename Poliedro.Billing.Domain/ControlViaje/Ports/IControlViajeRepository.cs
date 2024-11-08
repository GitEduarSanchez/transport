using Poliedro.Billing.Domain.ControlViaje.Entities;

namespace Poliedro.Billing.Domain.ControlViaje.Ports;

public interface IControlViajeRepository
{
    Task<bool> SaveAsync(ControlViajeEntity controlViaje);
    Task<IEnumerable<ControlViajeEntity>> GetAllAsync();
    Task<ControlViajeEntity> GetById(int idControlViaje);
}
