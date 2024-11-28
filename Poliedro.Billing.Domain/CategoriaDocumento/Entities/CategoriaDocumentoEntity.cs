using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.CategoriaDocumento.Entities;

public class CategoriaDocumentoEntity
{
    [Key]
    public int Id { get; set; }
    public string descripcion { get; set; }
   
   
}
