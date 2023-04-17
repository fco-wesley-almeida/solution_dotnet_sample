using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("perfil")]
[Index("Uuid", Name = "uk_perfil_uuid", IsUnique = true)]
public partial class Perfil: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [Column("criado_por")]
    [StringLength(100)]
    public string CriadoPor { get; set; } = null!;

    [Column("criado_em", TypeName = "timestamp without time zone")]
    public DateTime CriadoEm { get; set; }

    [Column("modificado_por")]
    [StringLength(100)]
    public string ModificadoPor { get; set; } = null!;

    [Column("modificado_em", TypeName = "timestamp without time zone")]
    public DateTime ModificadoEm { get; set; }

    [Column("ativo")]
    public bool Ativo { get; set; }

    [InverseProperty("Perfil")]
    public virtual ICollection<FinanciadoraPerfil> FinanciadoraPerfils { get; } = new List<FinanciadoraPerfil>();

    [InverseProperty("Perfil")]
    public virtual ICollection<IntegradorPerfil> IntegradorPerfils { get; } = new List<IntegradorPerfil>();

    [InverseProperty("Perfil")]
    public virtual ICollection<PerfilPermissao> PerfilPermissaos { get; } = new List<PerfilPermissao>();

    [InverseProperty("Perfil")]
    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
