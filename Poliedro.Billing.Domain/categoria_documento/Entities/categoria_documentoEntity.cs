using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.categoria_documento.Entities;

public class categoria_documentoEntity
{
    [Key]
    public int Id { get; set; }
    public string Descripcion { get; set; }
   
   
}
