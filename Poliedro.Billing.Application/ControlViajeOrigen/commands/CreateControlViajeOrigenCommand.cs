using MediatR;

namespace Poliedro.Billing.Application.ControlViajeOrigen.Commands;

public record CreateControlViajeOrigenCommand(int idcontrolviaje, int idorigen, int idciudad) : IRequest<bool>;
