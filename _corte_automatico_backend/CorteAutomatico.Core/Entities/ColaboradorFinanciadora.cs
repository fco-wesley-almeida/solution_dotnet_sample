using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("colaborador_financiadora")]
[Index("Uuid", Name = "uk_colaborador_financiadora_uuid", IsUnique = true)]
public partial class ColaboradorFinanciadora: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("usuario_id")]
    public int UsuarioId { get; set; }

    [Column("financiadora_id")]
    public int FinanciadoraId { get; set; }

    [Column("email_corporativo")]
    [StringLength(100)]
    public string EmailCorporativo { get; set; } = null!;

    [Column("telefone")]
    [StringLength(100)]
    public string Telefone { get; set; } = null!;

    [Column("matricula")]
    [StringLength(100)]
    public string Matricula { get; set; } = null!;

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
    [InverseProperty("ColaboradorFinanciadoras")]
    public virtual Financiadora Financiadora { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("ColaboradorFinanciadoras")]
    public virtual Usuario Usuario { get; set; } = null!;
}
