using MediatR;
using Poliedro.Billing.Domain.ControlViajeOrigen.Request;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands;

public record UpdateControlViajeOrigenCommand(int Id, ControlViajeOrigenRequest ControlViajeOrigenEntity) : IRequest<Unit>;

