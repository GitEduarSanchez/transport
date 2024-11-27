using MediatR;

namespace Poliedro.Billing.Application.Descargue.Commands;

public record DeleteDescargueCommand(int Id) : IRequest<bool>;

