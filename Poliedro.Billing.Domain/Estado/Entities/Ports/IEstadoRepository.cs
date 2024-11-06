
using Poliedro.Billing.Domain.Estado.Entities;

namespace Poliedro.Billing.Domain.Estado.Ports;

public interface IEstadoRepository
{
    Task<bool> SaveAsync(EstadoEntity estado);
    Task<IEnumerable<EstadoEntity>> GetAllAsync();
    Task<EstadoEntity> GetById(int Id);
    Task<bool> DeleteAsync(int Id);
}
