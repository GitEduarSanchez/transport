using Poliedro.Billing.Domain.departamento.Entities;

namespace Poliedro.Billing.Domain.departamento.Ports;

public interface IdepartamentoRepository
{
    Task<bool> SaveAsync(departamentoEntity departamento);
    Task<IEnumerable<departamentoEntity>> GetAllAsync();
    Task<departamentoEntity> GetById(int Id);
}
