using MediatR;

namespace Poliedro.Billing.Application.VehiculoTrailerDestino.Commands.CreateServerCommand;

public record CreateVehiculoTrailerDestinoCommand(int dvehiculotrailer,int iddestino,int idcuidad) : IRequest<bool>;


