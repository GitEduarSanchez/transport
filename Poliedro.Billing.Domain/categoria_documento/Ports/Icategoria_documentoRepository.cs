using Poliedro.Billing.Domain.categoria_documento.Entities;

namespace Poliedro.Billing.Domain.categoria_documento.Ports;

public interface Icategoria_documentoRepository
{
    Task<bool> SaveAsync(categoria_documentoEntity ciudad);
    Task<IEnumerable<categoria_documentoEntity>> GetAllAsync();
    Task<categoria_documentoEntity> GetById(int Id);
}
