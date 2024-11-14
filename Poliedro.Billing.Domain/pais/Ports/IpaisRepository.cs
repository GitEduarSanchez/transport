using Poliedro.Billing.Domain.pais.Entities;

namespace Poliedro.Billing.Domain.pais.Ports;

public interface IpaisRepository
{
    Task<bool> SaveAsync(paisEntity pais);
    Task<IEnumerable<paisEntity>> GetAllAsync();
    Task<paisEntity> GetById(int Id);
}
