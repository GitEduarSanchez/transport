using Poliedro.Billing.Domain.controlviaje_origen.Entities;
using Poliedro.Billing.Domain.controlviaje_origen.Request;

namespace Poliedro.Billing.Domain.controlviaje_origen.Entities.Ports;

public interface Icontrolviaje_origenRepository
{
    Task<bool> SaveAsync(controlviaje_origenEntity controlviaje_origen);
    Task<IEnumerable<controlviaje_origenEntity>> GetAllAsync();
    Task<controlviaje_origenEntity> GetById(int Idcontrolviaje_origen);
    Task<bool> DeleteAsync(int Idcontrolviaje_origen);
    Task UpdateAsync(int Idcontrolviaje_origen, controlviaje_origenEntity controlviaje_origen);
}
