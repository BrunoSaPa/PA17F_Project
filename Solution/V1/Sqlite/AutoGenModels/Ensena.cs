using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("ensena")]
public class Ensena
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_grupo")]
    public int? IdGrupo { get; set; }

    [Column("id_profesor")]
    public int? IdProfesor { get; set; }

    [ForeignKey("IdGrupo")]
    [InverseProperty("Ensenas")]
    public virtual Grupos? IdGrupoNavigation { get; set; }

    [ForeignKey("IdProfesor")]
    [InverseProperty("Ensenas")]
    public virtual Profesore? IdProfesorNavigation { get; set; }
}
