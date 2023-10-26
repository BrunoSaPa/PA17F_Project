using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("rlc_prs_equipo")]
public class RlcPrsEquipo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_prm_prestamo")]
    public int? IdPrmPrestamo { get; set; }

    [Column("id_equipo")]
    public int? IdEquipo { get; set; }

    [ForeignKey("IdEquipo")]
    [InverseProperty("RlcPrsEquipos")]
    public virtual Equipo? IdEquipoNavigation { get; set; }

    [ForeignKey("IdPrmPrestamo")]
    [InverseProperty("RlcPrsEquipos")]
    public virtual PrmPrestamos? IdPrmPrestamoNavigation { get; set; }
}
