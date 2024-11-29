using MediatR;

namespace Poliedro.Billing.Application.departamento.Commands;

public record DeletedepartamentoCommand(int Id) : IRequest<bool>;

