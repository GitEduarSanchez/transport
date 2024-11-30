using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.pais.Entities;

public class paisEntity
{
    [Key]
    public int Id { get; set; }
    public string Descripcion { get; set; }
    
   
}
