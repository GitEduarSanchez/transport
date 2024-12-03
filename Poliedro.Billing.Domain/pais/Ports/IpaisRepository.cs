

namespace Poliedro.Billing.Domain.pais.Entities.Ports;

public interface IpaisRepository
{
    Task<bool> SaveAsync(paisEntity pais);
    Task<IEnumerable<paisEntity>> GetAllAsync();
    Task<paisEntity> GetById(int Id);
    Task<bool> DeleteAsync(int Id);
    Task UpdateAsync(int Id, paisEntity pais);
}
