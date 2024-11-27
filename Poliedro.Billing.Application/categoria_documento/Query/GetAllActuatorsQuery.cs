using MediatR;
using Poliedro.Billing.Application.categoria_documento.Dto;
namespace Poliedro.Billing.Application.categoria_documento.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<categoria_documentoDto>>;

