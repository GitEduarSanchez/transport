using MediatR;

namespace Poliedro.Billing.Application.ControlViaje.Commands;

public record DeleteControlViajeCommand(int Id) : IRequest<bool>;

