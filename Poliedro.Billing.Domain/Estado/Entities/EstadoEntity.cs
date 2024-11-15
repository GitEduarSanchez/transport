using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.Estado.Entities;

public class EstadoEntity
{
    [Key]
    public int Id { get; set; }
    public string Descripcion { get; set; }
}
