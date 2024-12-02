using MediatR;
using Poliedro.Billing.Application.ControlViaje.Dto;


namespace Poliedro.Billing.Application.ControlViaje.Commands.Query;

public record GetAllControlViajeQuery : IRequest<IEnumerable<ControlViajeDto>>;

    