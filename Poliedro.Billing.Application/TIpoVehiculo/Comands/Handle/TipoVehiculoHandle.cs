using MediatR;
using Poliedro.Billing.Application.Conductor.Commands.CreateServerCommand;
using Poliedro.Billing.Domain.Conductor.Entities;
using Poliedro.Billing.Domain.Conductor.Ports;

namespace Poliedro.Billing.Application.Conductor.Handle;

public class ConductorHandle(IConductorRepository _conductorRepository) : IRequestHandler<CreateConductorCommand, bool>
{
    public async Task<bool> Handle(CreateConductorCommand request, CancellationToken cancellationToken)
    {
        ConductorEntity conductor = new() { Name = request.Name };
        return await _conductorRepository.SaveAsync(conductor);
    }
}
