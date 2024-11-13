using MediatR;

namespace Poliedro.Billing.Application.Origen.Commands.CreateServerCommand;

public record CreateOrigenCommand(string descripcion) : IRequest<bool>;


