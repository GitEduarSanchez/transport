using Poliedro.Billing.Domain.Destino.Entities;
namespace Poliedro.Billing.Domain.Destino.Ports;

public interface IDestinoRepository
{
    Task<bool> SaveAsync(DestinoEntity Destino);
    Task<IEnumerable<DestinoEntity>>GetAllAsync();
    Task<DestinoEntity> GetById(int Id);
}
