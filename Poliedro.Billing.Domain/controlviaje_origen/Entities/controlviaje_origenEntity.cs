using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.controlviaje_origen.Entities;

public class controlviaje_origenEntity
{
    [Key]
    public int idcontrolviaje_origen { get; set; }
    public int idcontrolviaje { get; set; }
    public int idorigen { get; set; }
    public int idciudad { get; set; }
}
