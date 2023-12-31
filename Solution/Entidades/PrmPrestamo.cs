﻿using System;
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
    public DateTime? FchInicio { get; set; }

    [Column("fch_fin", TypeName = "DATETIME")]
    public DateTime? FchFin { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public DateTime? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public DateTime? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public DateTime? FchEliminacion { get; set; }

    [Column("id_est_prm_prestamos")]
    public long? IdEstPrmPrestamos { get; set; }

    [Column("id_salon")]
    public long? IdSalon { get; set; }

    [InverseProperty("IdPrmPrestamoNavigation")]
    public virtual ICollection<EquiposPrm> EquiposPrms { get; set; } = new List<EquiposPrm>();

    [ForeignKey("IdEstPrmPrestamos")]
    [InverseProperty("PrmPrestamos")]
    public virtual EstPrmPrestamo? IdEstPrmPrestamosNavigation { get; set; }

    [ForeignKey("IdSalon")]
    [InverseProperty("PrmPrestamos")]
    public virtual Salon? IdSalonNavigation { get; set; }

    [ForeignKey("IdTpoPrmPrestamo")]
    [InverseProperty("PrmPrestamos")]
    public virtual TpsPrmPrestamo? IdTpoPrmPrestamoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("PrmPrestamos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
