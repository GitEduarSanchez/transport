using MediatR;

namespace Poliedro.Billing.Application.Destino.Commands.CreateServerCommand;

public record CreateDestinoCommand(string Descripcion) : IRequest<bool>;