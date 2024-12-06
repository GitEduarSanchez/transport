using MediatR;

namespace Poliedro.Billing.Application.pais.Commands;

public record DeletepaisCommand(int Id) : IRequest<bool>;

