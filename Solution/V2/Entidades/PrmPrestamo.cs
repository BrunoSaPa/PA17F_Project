using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("prm_prestamos")]
public partial class PrmPrestamo
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_tpo_prm_prestamo")]
    public long? IdTpoPrmPrestamo { get; set; }

    [Column("id_usuario")]
    public long? IdUsuario { get; set; }

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
    public virtual TpoPrmPrestamo? IdTpoPrmPrestamoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("PrmPrestamos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
