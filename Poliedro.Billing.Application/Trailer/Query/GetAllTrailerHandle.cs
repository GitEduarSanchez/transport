using MediatR;
using Poliedro.Billing.Application.Trailer.Dto;
using Poliedro.Billing.Domain.Trailer.Ports;

namespace Poliedro.Billing.Application.Trailer.Commands.Query;

public class GetAllTrailerQueryHandle(ITrailerRepository _trailerRepository) : IRequestHandler<GetAllTrailerQuery, IEnumerable<TrailerDto>>
{
    public async Task<IEnumerable<TrailerDto>> Handle(GetAllTrailerQuery request, CancellationToken cancellationToken)
    {
        var entities = await _trailerRepository.GetAllAsync();
        return entities.Select(trailer => new TrailerDto
        (
            id: trailer.Id,
            Descripcion: trailer.descripcion
        ));
    }
}
