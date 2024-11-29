using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.unidad_medida.Entities;

public class unidad_medidaEntity
{
    [Key]
    public int Id { get; set; }
    public string descripcion { get; set; }

   
}
