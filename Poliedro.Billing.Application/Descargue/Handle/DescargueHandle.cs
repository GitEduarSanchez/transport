using MediatR;
using Poliedro.Billing.Application.Descargue.Commands.CreateServerCommand;
using Poliedro.Billing.Domain.Descargue.Entities;
using Poliedro.Billing.Domain.Descargue.Ports;

namespace Poliedro.Billing.Application.Descargue.Handle;

public class DescargueHandle(IDescargueRepository _DescargueRepository) : IRequestHandler<CreateDescargueCommand, bool>
{
    public async Task<bool> Handle(CreateDescargueCommand request, CancellationToken cancellationToken)
    {
        DescargueEntity Descargue = new() { descriocion = request.descriocion };
        return await _DescargueRepository.SaveAsync(Descargue);
    }
}
