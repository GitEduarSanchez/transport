using MediatR;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands;

public record Createcontrolviaje_origenCommand(int idcontrolviaje, int idorigen, int idciudad) : IRequest<bool>;
