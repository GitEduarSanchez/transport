using System.ComponentModel.DataAnnotations;

namespace Poliedro.Billing.Domain.VehiculoTrailerDestino.Entities;

public class VehiculoTrailerDestinoEntity
{
    [Key]
    public int Id { get; set; }
    public int dvehiculotrailer { get; set; }
    public int iddestino { get; set; }
    public int idcuidad { get; set; }
    
   
}
