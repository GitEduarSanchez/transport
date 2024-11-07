using MediatR;

namespace Poliedro.Billing.Application.ControlViajeProducto.Commands;

public record CreateControlViajeProductoCommand(int idControlViaje, int idProducto) : IRequest<bool>;