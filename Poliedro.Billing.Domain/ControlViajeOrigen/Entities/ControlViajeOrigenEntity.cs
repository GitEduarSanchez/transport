using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.ControlViajeOrigen.Entities;

public class ControlViajeOrigenEntity
{
    [Key]
    public int Id { get; set; }
    public string idcontrolviaje { get; set; }
     public string idorigen { get; set; }
      public string idciudad { get; set; }
}
