using MediatR;
using Poliedro.Billing.Application.Ciudad.Dto;
namespace Poliedro.Billing.Application.Ciudad.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<CiudadDto>>;

