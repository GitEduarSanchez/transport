using MediatR;
using Poliedro.Billing.Application.Vehiculo.Dto;

namespace Poliedro.Billing.Application.Vehiculo.Query;

public record GetByIdVehiculoQuery(int idvehiculo): IRequest<VehiculoDto>;

