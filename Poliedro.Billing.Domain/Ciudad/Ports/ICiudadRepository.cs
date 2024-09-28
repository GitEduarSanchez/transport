﻿using Poliedro.Billing.Domain.Ciudad.Entities;

namespace Poliedro.Billing.Domain.Ciudad.Ports;

public interface ICiudadRepository
{
    Task<bool> SaveAsync(CiudadEntity ciudad);
}
