using MediatR;

namespace Poliedro.Billing.Application.Ciudad.Commands.CreateServerCommand;

public record CreateCiudadCommand(string descripcion,int iddepartamento) : IRequest<bool>;


