using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.Descargue.Entities;

public class DescargueEntity
{
    [Key]
    public int iddescargue { get; set; }
    public required string descriocion { get; set; }

}
