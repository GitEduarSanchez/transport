using MediatR;

namespace Poliedro.Billing.Application.Ciudad.Commands;

public record CreateCiudadCommand(string descripcion, int iddepartamento) : IRequest<bool>;


