using MediatR;
using Poliedro.Billing.Domain.ControlViaje.Request;

namespace Poliedro.Billing.Application.ControlViaje.Commands;

public record UpdateControlViajeCommand(int Id, ControlViajeRequest ControlViajeEntity) : IRequest<Unit>;

