using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.Concepto.Entities;

public class ConceptoEntity
{
    [Key]
    public int IdConcepto { get; set; }
    public string descripcion { get; set; }
}
