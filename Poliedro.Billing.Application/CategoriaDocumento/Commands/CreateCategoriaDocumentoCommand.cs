using MediatR;

namespace Poliedro.Billing.Application.CategoriaDocumento.Commands;

public record CreateCategoriaDocumentoCommand(string descripcion) : IRequest<bool>;


