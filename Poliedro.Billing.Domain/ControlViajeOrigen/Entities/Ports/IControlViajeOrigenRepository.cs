using Poliedro.Billing.Domain.ControlViajeOrigen.Entities;
using Poliedro.Billing.Domain.ControlViajeOrigen.Request;

namespace Poliedro.Billing.Domain.ControlViajeOrigen.Entities.Ports;

public interface IControlViajeOrigenRepository
{
    Task<bool> SaveAsync(ControlViajeOrigenEntity controlviajeorigen);
    Task<IEnumerable<ControlViajeOrigenEntity>> GetAllAsync();
    Task<ControlViajeOrigenEntity> GetById(int Id);
    Task<bool> DeleteAsync(int Id);
    Task UpdateAsync(int Id, ControlViajeOrigenEntity controlviajeorigen);
}
