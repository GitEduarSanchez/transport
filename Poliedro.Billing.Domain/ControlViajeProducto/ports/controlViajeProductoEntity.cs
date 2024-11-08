using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.ControlViajeProducto.Entities;

public class controlViajeProductoEntity
{
    [Key]
    public int idControlViajeProducto { get; set; }
    public int idControlViaje { get; set; }
    public int idProducto { get; set; }
}
