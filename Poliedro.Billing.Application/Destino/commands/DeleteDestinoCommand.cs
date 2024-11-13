using MediatR;

namespace Poliedro.Billing.Application.Destino.Commands;

public record DeleteDestinoCommand(int Id) : IRequest<bool>;

