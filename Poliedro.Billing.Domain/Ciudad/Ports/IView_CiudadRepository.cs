using Poliedro.Billing.Domain.Ciudad.Entities;

namespace Poliedro.Billing.Domain.Ciudad.Ports;

public interface IView_CiudadRepository
{
    Task<bool> SaveAsync(View_CiudadEntity ciudad);
    Task<IEnumerable<View_CiudadEntity>> GetAllAsync();
}
