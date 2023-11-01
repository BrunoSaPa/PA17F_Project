using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("estudiantes")]
public partial class Estudiante
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_usuario")]
    public long? IdUsuario { get; set; }

    [Column("id_grupo")]
    public long? IdGrupo { get; set; }

    [Column("registro")]
    public long? Registro { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public DateTime? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public DateTime? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public DateTime? FchEliminacion { get; set; }

    [ForeignKey("IdGrupo")]
    [InverseProperty("Estudiantes")]
    public virtual Grupo? IdGrupoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Estudiantes")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
