using MediatR;
using Poliedro.Billing.Application.VehiculoTrailerDestino.Dto;
namespace Poliedro.Billing.Application.VehiculoTrailerDestino.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<VehiculoTrailerDestinoDto>>;

