using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("prm_prestamos")]
public class PrmPrestamos
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_tpo_prm_prestamo")]
    public int? IdTpoPrmPrestamo { get; set; }

    [Column("id_usuario")]
    public int? IdUsuario { get; set; }

    [Column("fch_inicio", TypeName = "DATETIME")]
    public byte[]? FchInicio { get; set; }

    [Column("fch_fin", TypeName = "DATETIME")]
    public byte[]? FchFin { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public byte[]? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public byte[]? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public byte[]? FchEliminacion { get; set; }

    [ForeignKey("IdTpoPrmPrestamo")]
    [InverseProperty("PrmPrestamos")]
    public virtual TpsPrmPrestamos? IdTpoPrmPrestamoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("PrmPrestamos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    [InverseProperty("IdPrmPrestamoNavigation")]
    public virtual ICollection<RlcPrsEquipo> RlcPrsEquipos { get; set; } = new List<RlcPrsEquipo>();
}
