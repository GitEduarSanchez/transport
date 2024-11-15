using MediatR;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands;

public record Deletecontrolviaje_origenCommand(int Id) : IRequest<bool>;

