using MediatR;

namespace Poliedro.Billing.Application.Producto.Commands;

public record DeleteProductoCommand(int Id) : IRequest<bool>;

