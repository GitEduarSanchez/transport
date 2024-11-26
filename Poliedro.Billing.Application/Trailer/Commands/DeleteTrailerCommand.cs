using MediatR;

namespace Poliedro.Billing.Application.Trailer.Commands;

public record DeleteTrailerCommand(int Id) : IRequest<bool>;

