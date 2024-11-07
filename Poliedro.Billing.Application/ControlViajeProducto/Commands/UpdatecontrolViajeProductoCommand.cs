using MediatR;
using Poliedro.Billing.Domain.ControlViajeProducto.Request;

namespace Poliedro.Billing.Application.ControlViajeProducto.Commands;

public record UpdatecontrolViajeProductoCommand(int idControlViajeProducto, ControlViajeProductoRequest ControlViajeProductoEntity) : IRequest<Unit>;

