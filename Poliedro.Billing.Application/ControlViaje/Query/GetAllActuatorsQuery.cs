﻿using MediatR;
using Poliedro.Billing.Application.ControlViaje.Dto;
namespace Poliedro.Billing.Application.ControlViaje.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<ControlViajeDto>>;

