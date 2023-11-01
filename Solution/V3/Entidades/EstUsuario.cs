﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entidades;

[Table("est_usuarios")]
public partial class EstUsuario
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [InverseProperty("IdEstUsuarioNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
