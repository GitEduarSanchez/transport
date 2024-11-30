using MediatR;
using Poliedro.Billing.Application.pais.Dto;

namespace Poliedro.Billing.Application.pais.Query;

public record GetByIdpaisQuery(int Id): IRequest<paisDto>;

