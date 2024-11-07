using MediatR;
using Poliedro.Billing.Application.Estado.Commands.Dto;

namespace Poliedro.Billing.Application.Estado.Commands.Query;

public record GetAllEstadoQuery : IRequest<IEnumerable<EstadoDto>>;

