using MediatR;

namespace Poliedro.Billing.Application.ControlViaje.Commands;

public record CreateControlViajeCommand(DateTime fecha, string guia, int idVehiculoTrailer) : IRequest<bool>;