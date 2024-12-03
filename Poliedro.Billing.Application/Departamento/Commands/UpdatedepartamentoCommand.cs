using MediatR;
using Poliedro.Billing.Domain.departamento.Request;

namespace Poliedro.Billing.Application.departamento.Commands;

public record UpdatedepartamentoCommand(int Id, departamentoRequest departamentoEntity) : IRequest<Unit>;

