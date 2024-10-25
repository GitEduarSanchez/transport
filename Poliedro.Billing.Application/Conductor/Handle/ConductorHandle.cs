using MediatR;
using Poliedro.Billing.Application.Producto.Commands.CreateServerCommand;
using Poliedro.Billing.Domain.Conductor.Entities;
using Poliedro.Billing.Domain.Conductor.Ports;


namespace Poliedro.Billing.Application.Conductor.Handle;

    public class ConductorHandle(IConductorRepository _ConductorRepository) : IRequestHandler<CreateConductorCommand, bool>
    {
        public async Task<bool> Handle(CreateConductorCommand request, CancellationToken cancellationToken)
        {
            ConductorEntity conductor = new ConductorEntity() { Name=request.Name };
            return await _ConductorRepository.SaveAsync(conductor);
        }
    }

