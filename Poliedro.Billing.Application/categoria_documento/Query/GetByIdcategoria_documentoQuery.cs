using MediatR;
using Poliedro.Billing.Application.categoria_documento.Dto;

namespace Poliedro.Billing.Application.categoria_documento.Query;

public record GetByIdcategoria_documentoQuery(int Id): IRequest<categoria_documentoDto>;

