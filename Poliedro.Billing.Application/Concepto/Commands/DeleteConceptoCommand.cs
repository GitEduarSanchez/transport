using MediatR;

namespace Poliedro.Billing.Application.Concepto.Commands;

public record DeleteConceptoCommand(int Id) : IRequest<bool>;

