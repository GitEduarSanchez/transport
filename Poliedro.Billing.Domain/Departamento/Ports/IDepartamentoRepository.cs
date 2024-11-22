using Poliedro.Billing.Domain.departamento.Entities;
using Poliedro.Billing.Domain.departamento.Request;

namespace Poliedro.Billing.Domain.departamento.Entities.Ports;

public interface IdepartamentoRepository
{
    Task<bool> SaveAsync(departamentoEntity departamento);
    Task<IEnumerable<departamentoEntity>> GetAllAsync();
    Task<departamentoEntity> GetById(int Id);
    Task<bool> DeleteAsync(int Id);
    Task UpdateAsync(int Id, departamentoEntity departamento);
}
