using MediatR;
using Poliedro.Billing.Domain.ControlViajeProducto.Request;

namespace Poliedro.Billing.Application.ControlViajeProducto.Commands;

public record UpdateControlViajeProductoCommand(int Id, ControlViajeProductoRequest controlViajeProductoEntity) : IRequest<Unit>;
