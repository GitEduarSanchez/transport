using Poliedro.Billing.Domain.VehiculoTrailerDestino.Entities;

namespace Poliedro.Billing.Domain.VehiculoTrailerDestino.Ports;

public interface IVehiculoTrailerDestinoRepository
{
    Task<bool> SaveAsync(VehiculoTrailerDestinoEntity VehiculoTrailerDestino);
    Task<IEnumerable<VehiculoTrailerDestinoEntity>> GetAllAsync();
    Task<VehiculoTrailerDestinoEntity> GetById(int VehiculoTrailerDestino);
}
