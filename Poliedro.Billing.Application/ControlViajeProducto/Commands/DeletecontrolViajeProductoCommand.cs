using MediatR;

namespace Poliedro.Billing.Application.ControlViajeProducto.Commands;

public record DeletecontrolViajeProductoCommand(int idControlViajeProducto) : IRequest<bool>;

