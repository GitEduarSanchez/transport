using MediatR;
using Poliedro.Billing.Application.Conductor.Dto;

namespace Poliedro.Billing.Application.Conductor.Query;

public record GetByIdConductorQuery(int Id): IRequest<ConductorDto>;

