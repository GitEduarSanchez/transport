using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.Producto.Entities;

public class ProductoEntity
{
    [Key]
    public int Id { get; set; }
    public string descripcion { get; set; }

    public int idunidad_medida { get; set; }
}
