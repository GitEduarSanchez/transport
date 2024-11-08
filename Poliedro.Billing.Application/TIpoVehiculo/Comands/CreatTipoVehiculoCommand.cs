using MediatR;

namespace Poliedro.Billing.Application.Conductor.Commands.CreateServerCommand;

public record CreateTipoVehiculoCommand(string Descripcion) : IRequest<bool>;