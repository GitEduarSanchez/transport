using Poliedro.Billing.Domain.Descargue.Entities;

namespace Poliedro.Billing.Domain.Descargue.Ports;

public interface IDescargueRepository
{
    Task<bool> SaveAsync(DescargueEntity descargue);
    Task<IEnumerable<DescargueEntity>> GetAllAsync();
    Task<DescargueEntity> GetById(int iddescargue);
}
