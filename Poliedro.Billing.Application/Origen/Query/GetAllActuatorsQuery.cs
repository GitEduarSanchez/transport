using MediatR;
using Poliedro.Billing.Application.Origen.Dto;
namespace Poliedro.Billing.Application.Origen.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<OrigenDto>>;

