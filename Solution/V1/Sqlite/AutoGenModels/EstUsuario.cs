using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sqlite.AutoGens;

[Table("est_usuarios")]
public class EstUsuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }


    
    [Column("descripcion")]
    public string? Descripcion { get; set; }
}
