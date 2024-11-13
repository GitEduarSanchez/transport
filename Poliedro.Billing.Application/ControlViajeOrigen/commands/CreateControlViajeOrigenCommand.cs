using MediatR;

namespace Poliedro.Billing.Application.Estado.Commands;

public record CreateEstadoCommand(int idcontrolviaje, int idorigen, int idciudad) : IRequest<bool>;
