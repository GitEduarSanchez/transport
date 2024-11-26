using MediatR;
using Poliedro.Billing.Application.Trailer.Dto;

namespace Poliedro.Billing.Application.Trailer.Commands.Query;

public record GetByIdTrailerQuery(int Id) : IRequest<TrailerDto>;

