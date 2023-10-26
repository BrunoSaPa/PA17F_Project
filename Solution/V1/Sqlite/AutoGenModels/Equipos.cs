using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("equipos")]
public  class Equipos
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("cnt_disponible")]
    public long? CntDisponible { get; set; }

    [Column("nombre")]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [InverseProperty("IdEquipoNavigation")]
    public virtual ICollection<RlcPrsEquipo> RlcPrsEquipos { get; set; } = new List<RlcPrsEquipo>();
}
