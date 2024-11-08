using Poliedro.Billing.Domain.Estado.Entities;
using Poliedro.Billing.Domain.Estado.Request;

namespace Poliedro.Billing.Domain.Estado.Entities.Ports;

public interface IEstadoRepository
{
    Task<bool> SaveAsync(EstadoEntity estado);
    Task<IEnumerable<EstadoEntity>> GetAllAsync();
    Task<EstadoEntity> GetById(int Id);
    Task<bool> DeleteAsync(int Id);
    Task UpdateAsync(int Id, EstadoEntity estado);
}
