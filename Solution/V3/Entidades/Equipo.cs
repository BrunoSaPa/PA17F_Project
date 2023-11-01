using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("equipos")]
public partial class Equipo
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("cnt_disponible")]
    public long? CntDisponible { get; set; }

    [Column("nombre")]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public DateTime? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public DateTime? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public DateTime? FchEliminacion { get; set; }

    [InverseProperty("IdEquipoNavigation")]
    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    [InverseProperty("IdEquipoNavigation")]
    public virtual ICollection<RlcPrsEquipo> RlcPrsEquipos { get; set; } = new List<RlcPrsEquipo>();
}
