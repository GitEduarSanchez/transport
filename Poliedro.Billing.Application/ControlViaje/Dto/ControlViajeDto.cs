using System.Data.Common;

namespace Poliedro.Billing.Application.ControlViaje.Dto;

public record ControlViajeDto(int idControlViaje, DateTime fecha, string guia, int idVehiculoTrailer);



