using MediatR;
using Poliedro.Billing.Application.controlviaje_origen.Commands.Dto;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands.Query;

public record GetAllcontrolviaje_origenQuery : IRequest<IEnumerable<controlviaje_origenDto>>;

