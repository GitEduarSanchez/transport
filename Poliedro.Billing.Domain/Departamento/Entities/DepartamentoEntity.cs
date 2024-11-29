using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.departamento.Entities;

public class departamentoEntity
{
    [Key]
    public int Id { get; set; }
    public string descripcion { get; set; }
    public int idpais { get; set; }
   
}
