using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.Conductor.Entities;

public class tipovehiculoEntity
{
    [Key]
    public int Id { get; set; }
    public string tipovehiculo { get; set; }
}
