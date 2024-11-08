using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.ControlViaje.Entities;

public class ControlViajeEntity
{
    [Key]
    public int idControlViaje { get; set; }

    public DateTime fecha { get; set; }

    public string guia { get; set; }

    public int idVehiculoTrailer { get; set; }
}
