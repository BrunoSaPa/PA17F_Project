﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("profesores")]
public partial class Profesor
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_usuario")]
    public long? IdUsuario { get; set; }

    [Column("nomina")]
    public long? Nomina { get; set; }

    [Column("fch_creacion", TypeName = "DATETIME")]
    public DateTime? FchCreacion { get; set; }

    [Column("fch_modificacion", TypeName = "DATETIME")]
    public DateTime? FchModificacion { get; set; }

    [Column("fch_eliminacion", TypeName = "DATETIME")]
    public DateTime? FchEliminacion { get; set; }

    [Column("id_grupo")]
    public long? IdGrupo { get; set; }

    [ForeignKey("IdGrupo")]
    [InverseProperty("Profesores")]
    public virtual Grupo? IdGrupoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Profesores")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
