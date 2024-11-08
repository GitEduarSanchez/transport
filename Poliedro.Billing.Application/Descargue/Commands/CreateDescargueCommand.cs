using MediatR;

namespace Poliedro.Billing.Application.Descargue.Commands;

public record CreateDescargueCommand(int iddescargue, string descriocion) : IRequest<bool>;
