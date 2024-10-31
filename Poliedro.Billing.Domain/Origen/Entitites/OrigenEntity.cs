using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.Origen.Entities;

public class OrigenEntity
{
    [Key]
    public int Id { get; set; }
    public string Descripcion { get; set; }
    
   
}
