using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("equipos_prm")]
public partial class EquiposPrm
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_equipos")]
    public long? IdEquipos { get; set; }

    [Column("id_prm_prestamo")]
    public long? IdPrmPrestamo { get; set; }

    [ForeignKey("IdEquipos")]
    [InverseProperty("EquiposPrms")]
    public virtual Equipo? IdEquiposNavigation { get; set; }

    [ForeignKey("IdPrmPrestamo")]
    [InverseProperty("EquiposPrms")]
    public virtual PrmPrestamo? IdPrmPrestamoNavigation { get; set; }

    [InverseProperty("IdPrmEquipos1")]
    public virtual ICollection<RlcPrsEquipo> RlcPrsEquipos { get; set; } = new List<RlcPrsEquipo>();
}
