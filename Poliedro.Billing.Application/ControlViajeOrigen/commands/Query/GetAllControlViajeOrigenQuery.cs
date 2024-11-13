using MediatR;
using Poliedro.Billing.Application.ControlViajeOrigen.Commands.Dto;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands.Query;

public record GetAllControlViajeOrigenQuery : IRequest<IEnumerable<ControlViajeOrigenDto>>;

