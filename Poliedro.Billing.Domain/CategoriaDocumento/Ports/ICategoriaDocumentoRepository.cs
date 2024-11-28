using Poliedro.Billing.Domain.CategoriaDocumento.Entities;

namespace Poliedro.Billing.Domain.CategoriaDocumento.Ports;

public interface ICategoriaDocumentoRepository
{
    Task<bool> SaveAsync(CategoriaDocumentoEntity ciudad);
    Task<IEnumerable<CategoriaDocumentoEntity>> GetAllAsync();
    Task<CategoriaDocumentoEntity> GetById(int Id);
}
