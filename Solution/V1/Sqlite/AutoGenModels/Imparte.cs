using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("imparte")]
public class Imparte
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_profesor")]
    public int? IdProfesor { get; set; }

    [Column("id_materia")]
    public int? IdMateria { get; set; }

    [ForeignKey("IdMateria")]
    [InverseProperty("Impartes")]
    public virtual Materias? IdMateriaNavigation { get; set; }

    [ForeignKey("IdProfesor")]
    [InverseProperty("Impartes")]
    public virtual Profesores? IdProfesorNavigation { get; set; }
}
