using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("mantenimiento")]
public partial class Mantenimiento
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_tpo_mantenimiento")]
    public long? IdTpoMantenimiento { get; set; }

    [Column("id_equipo")]
    public long? IdEquipo { get; set; }

    [Column("descripciones")]
    public string? Descripciones { get; set; }

    [Column("refaccion")]
    public string? Refaccion { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public DateTime? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public DateTime? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public DateTime? FchEliminacion { get; set; }

    [Column("fch_inicio", TypeName = "DATETIME")]
    public DateTime? FchInicio { get; set; }

    [Column("fch_fin", TypeName = "DATETIME")]
    public DateTime? FchFin { get; set; }

    [ForeignKey("IdEquipo")]
    [InverseProperty("Mantenimientos")]
    public virtual Equipo? IdEquipoNavigation { get; set; }

    [ForeignKey("IdTpoMantenimiento")]
    [InverseProperty("Mantenimientos")]
    public virtual TpoMantenimiento? IdTpoMantenimientoNavigation { get; set; }
}
