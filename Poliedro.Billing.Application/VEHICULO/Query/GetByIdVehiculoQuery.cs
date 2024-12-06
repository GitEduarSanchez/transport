using MediatR;
using Poliedro.Billing.Application.Vehiculo.Dto;

namespace Poliedro.Billing.Application.Vehhiculo.Query;

public record GetByidvehiculoQuery(int idvehiculo) : IRequest<VehiculoDto>;

