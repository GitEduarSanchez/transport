using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.TipoVehiculo.Entities;

public class TipoVehiculoEntity
{
    [Key]
    public int IdTipoVehiculo { get; set; }
    public string descripcion { get; set; }
    public int Id { get; set; }
}
