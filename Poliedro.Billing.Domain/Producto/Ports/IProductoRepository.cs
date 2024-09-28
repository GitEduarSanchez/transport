﻿using Poliedro.Billing.Domain.Producto.Entities;

namespace Poliedro.Billing.Domain.Producto.Ports;

public interface IProductoRepository
{
    Task<bool> SaveAsync(ProductoEntity producto);
}
