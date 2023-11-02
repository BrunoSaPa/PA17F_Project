using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("est_prm_prestamos")]
public partial class EstPrmPrestamos
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [InverseProperty("IdEstPrmPrestamosNavigation")]
    public virtual ICollection<PrmPrestamo> PrmPrestamos { get; set; } = new List<PrmPrestamo>();
 
}
