using MediatR;

namespace Poliedro.Billing.Application.departamento.Commands;

public record CreatedepartamentoCommand(string descripcion, int idpais) : IRequest<bool>;


