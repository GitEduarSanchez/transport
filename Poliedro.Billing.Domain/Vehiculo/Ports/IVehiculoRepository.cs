﻿using Poliedro.Billing.Domain.Vehiculo.Entities;

namespace Poliedro.Billing.Domain.Vehiculo.Ports;

public interface IVehiculoRepository
{
   Task<bool> SaveAsync(VehiculoEntity vehiculo);
   Task<IEnumerable<VehiculoEntity>> GetAllAsync();
    Task GetByidvehiculo(object idevehiculo);
}
