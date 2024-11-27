using MediatR;

namespace Poliedro.Billing.Application.categoria_documento.Commands;

public record Createcategoria_documentoCommand(string descripcion) : IRequest<bool>;


