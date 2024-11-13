using Poliedro.Billing.Domain.unidad_medida.Entities;

namespace Poliedro.Billing.Domain.unidad_medida.Ports;

public interface Iunidad_medidaRepository
{
    
    Task<bool> SaveAsync(unidad_medidaEntity unidad_medida);
    Task<IEnumerable<unidad_medidaEntity>> GetAllAsync();
    Task<unidad_medidaEntity> GetById(int id);
}
