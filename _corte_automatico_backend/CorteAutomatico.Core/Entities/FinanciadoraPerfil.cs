using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("financiadora_perfil")]
[Index("Uuid", Name = "uk_financiadora_perfil_uuid", IsUnique = true)]
public partial class FinanciadoraPerfil: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("perfil_id")]
    public int PerfilId { get; set; }

    [Column("financiadora_id")]
    public int FinanciadoraId { get; set; }

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

    [ForeignKey("FinanciadoraId")]
    [InverseProperty("FinanciadoraPerfils")]
    public virtual Financiadora Financiadora { get; set; } = null!;

    [ForeignKey("PerfilId")]
    [InverseProperty("FinanciadoraPerfils")]
    public virtual Perfil Perfil { get; set; } = null!;
}
