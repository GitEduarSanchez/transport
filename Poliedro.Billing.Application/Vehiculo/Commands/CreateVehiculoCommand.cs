﻿using MediatR;

namespace Poliedro.Billing.Application.Vehiculo.Commands;

public record CreateVehiculoCommand(string placa, int idmarca, int tipovehiculo) : IRequest<bool>;