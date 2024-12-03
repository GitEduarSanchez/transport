using MediatR;

namespace Poliedro.Billing.Application.pais.Commands;

public record CreatepaisCommand(string descripcion) : IRequest<bool>;


