using MediatR;
using Poliedro.Billing.Domain.Trailer.Request;

namespace Poliedro.Billing.Application.Trailer.Commands;

public record UpdateTrailerCommand(int Id, TrailerRequest TrailerEntity) : IRequest<Unit>;

