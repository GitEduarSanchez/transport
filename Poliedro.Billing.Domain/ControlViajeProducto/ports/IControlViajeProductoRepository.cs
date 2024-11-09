using Poliedro.Billing.Domain.ControlViajeProducto.Entities;

namespace Poliedro.Billing.Domain.ControlViajeProducto.Ports;

public interface IControlViajeProductoRepository
{
    Task<bool> SaveAsync(ControlViajeProductoEntity ControlViajeProducto);
    Task<IEnumerable<ControlViajeProductoEntity>> GetAllAsync();

    Task<ControlViajeProductoEntity> GetById(int idControlViajeProducto);
    Task<bool> DeleteAsync(int idControlViajeProducto);

    Task UpdateAsync(int idControlViajeProducto, controlViajeProductoEntity controlViajeProducto);
}

