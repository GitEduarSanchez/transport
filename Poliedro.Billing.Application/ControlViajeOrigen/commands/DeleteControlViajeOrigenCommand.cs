using MediatR;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands;

public record DeleteControlViajeOrigenCommand(int idcontrolviaje, int idorigen, int idciudad) : IRequest<bool>;

