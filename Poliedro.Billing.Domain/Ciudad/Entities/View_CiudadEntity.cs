using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.View_Ciudad.Entities;

public class View_CiudadEntity
{
    [Key]
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public int Iddepartamento { get; set; }
   
}
