using Poliedro.Billing.Domain.Destino.Entities;
namespace Poliedro.Billing.Domain.Destino.Ports;

public interface IDestinoRepository
{
    Task<bool> SaveAsync(DestinoEntity Destino);
    Task<IEnumerable<DestinoEntity>>GetAllAsync();
    Task<DestinoEntity> GetById(int Id);
    Task<bool> DeleteAsync(int Id);
    Task UpdateAsync(int Id, DestinoEntity destino);
}
