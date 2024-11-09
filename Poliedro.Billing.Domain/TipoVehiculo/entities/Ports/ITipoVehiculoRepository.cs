using Poliedro.Billing.Domain.TipoVehiculo.Entities;
using Poliedro.Billing.Domain.TipoVehiculo.Request;

namespace Poliedro.Billing.Domain.TipoVehiculo.Ports;

public interface ITipoVehiculoRepository
{
    Task<bool> SaveAsync(TipoVehiculoEntity tipovehiculo);
    Task<IEnumerable<TipoVehiculoEntity>> GetAllAsync();
    Task<TipoVehiculoEntity> GetById(int Id);
     Task<bool> DeleteAsync(int Id);
    Task UpdateAsync(int Id, TipoVehiculoEntity tipovehiculo);
}
