using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.Destino.Entities;

public class DestinoEntity
{
    [Key]
    public int iddestino { get; set; }
    public string descripcion { get; set; }
}
