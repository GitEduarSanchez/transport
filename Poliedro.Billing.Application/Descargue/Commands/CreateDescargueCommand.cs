using MediatR;

namespace Poliedro.Billing.Application.Descargue.Commands.CreateServerCommand;

public record CreateDescargueCommand(int iddescargue, string descriocion) : IRequest<bool>;
