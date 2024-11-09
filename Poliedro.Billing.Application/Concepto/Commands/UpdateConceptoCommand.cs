using MediatR;
using Poliedro.Billing.Domain.Estado.Request;

namespace Poliedro.Billing.Application.Concepto.Commands;

public record UpdateConceptoCommand(int Id, EstadoRequest ConceptoEntity) : IRequest<Unit>;

