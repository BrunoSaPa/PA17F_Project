using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("rlc_prs_equipo")]
public partial class RlcPrsEquipo
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_prm_prestamo")]
    public long? IdPrmPrestamo { get; set; }

    [Column("id_equipo")]
    public long? IdEquipo { get; set; }

    [ForeignKey("IdEquipo")]
    [InverseProperty("RlcPrsEquipos")]
    public virtual Equipo? IdEquipoNavigation { get; set; }

    [ForeignKey("IdPrmPrestamo")]
    [InverseProperty("RlcPrsEquipos")]
    public virtual PrmPrestamo? IdPrmPrestamoNavigation { get; set; }
}
