using MediatR;
using Poliedro.Billing.Application.departamento.Dto;
namespace Poliedro.Billing.Application.departamento.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<departamentoDto>>;

