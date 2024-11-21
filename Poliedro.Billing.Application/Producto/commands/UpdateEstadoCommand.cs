using MediatR;
using Poliedro.Billing.Domain.Producto.Request;

namespace Poliedro.Billing.Application.Producto.Commands;

public record UpdateProductoCommand(int Id, ProductoRequest ProductoEntity) : IRequest<Unit>;

