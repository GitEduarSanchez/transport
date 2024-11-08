using MediatR;

namespace Poliedro.Billing.Application.Producto.commands;

public record CreateProductoCommand(string descripcion, int idunidad_medida) : IRequest<bool>;