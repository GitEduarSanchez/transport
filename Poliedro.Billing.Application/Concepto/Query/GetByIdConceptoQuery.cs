using MediatR;
using Poliedro.Billing.Application.Concepto.Dto;

namespace Poliedro.Billing.Application.Concepto.Commands.Query;

public record GetByIdConceptoQuery(int idConcepto) : IRequest<ConceptoDto>;

