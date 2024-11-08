using MediatR;
using Poliedro.Billing.Application.Ciudad.Dto;

namespace Poliedro.Billing.Application.Ciudad.Query;

public record GetByIdCiudadQuery(int Id): IRequest<CiudadDto>;

