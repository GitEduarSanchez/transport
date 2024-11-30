using MediatR;
using Poliedro.Billing.Application.CategoriaDocumento.Dto;
namespace Poliedro.Billing.Application.CategoriaDocumento.Query;

public record GetAllActuatorsQuery: IRequest<IEnumerable<CategoriaDocumentoDto>>;

