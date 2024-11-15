using MediatR;
using Poliedro.Billing.Domain.controlviaje_origen.Request;

namespace Poliedro.Billing.Application.controlviaje_origen.Commands;

public record Updatecontrolviaje_origenCommand(int Id, controlviaje_origenRequest controlviaje_origenEntity) : IRequest<Unit>;

