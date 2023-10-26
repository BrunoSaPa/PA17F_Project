using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("estudiantes")]
public class Estudiantes
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_usuario")]
    public int? IdUsuario { get; set; }

    [Column("id_grupo")]
    public int? IdGrupo { get; set; }

    [Column("registro")]
    public int? Registro { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public DateTime? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public DateTime? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public DateTime? FchEliminacion { get; set; }

    [ForeignKey("IdGrupo")]
    [InverseProperty("Estudiantes")]
    public virtual Grupos? IdGrupoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Estudiantes")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
