using MediatR;

namespace Poliedro.Billing.Application.Concepto.Commands;

public record CreateConceptoCommand(string descripcion) : IRequest<bool>;