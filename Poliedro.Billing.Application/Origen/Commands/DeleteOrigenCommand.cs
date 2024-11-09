using MediatR;

namespace Poliedro.Billing.Application.Origen.Commands;

public record DeleteOrigenCommand(int Id) : IRequest<bool>;

