using MediatR;

namespace Poliedro.Billing.Application.Destino.Commands;

public record CreateDestinoCommand(string Descripcion) : IRequest<bool>;
