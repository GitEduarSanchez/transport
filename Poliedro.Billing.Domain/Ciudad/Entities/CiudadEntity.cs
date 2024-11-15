using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.Ciudad.Entities;

public class CiudadEntity
{
    [Key]
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public int Iddepartamento { get; set; }
   
}
