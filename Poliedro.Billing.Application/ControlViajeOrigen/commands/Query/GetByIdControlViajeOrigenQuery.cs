using MediatR;
using Poliedro.Billing.Application.ControlViajeOrigen.Commands.Dto;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands.Query;

public record GetByIdControlViajeOrigenQuery(int Id) : IRequest<ControlViajeOrigenDto>;

