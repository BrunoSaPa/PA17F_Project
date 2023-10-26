using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("salones")]
public class Salones
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_division")]
    public int? IdDivision { get; set; }

    [Column("nmr_salon")]
    public int? NmrSalon { get; set; }

    [ForeignKey("IdDivision")]
    [InverseProperty("Salones")]
    public virtual Divisione? IdDivisionNavigation { get; set; }
}
