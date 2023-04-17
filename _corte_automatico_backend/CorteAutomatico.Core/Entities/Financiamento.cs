using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("financiamento")]
[Index("Uuid", Name = "uk_financiamento_uuid", IsUnique = true)]
public partial class Financiamento: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("financiadora_id")]
    public int FinanciadoraId { get; set; }

    [Column("instalacao_id")]
    public int InstalacaoId { get; set; }

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

    [Column("valor_total")]
    [Precision(12, 3)]
    public decimal ValorTotal { get; set; }

    [Column("moeda")]
    [StringLength(100)]
    public string Moeda { get; set; } = null!;

    [Column("data_encerramento")]
    public DateOnly DataEncerramento { get; set; }

    [ForeignKey("FinanciadoraId")]
    [InverseProperty("Financiamentos")]
    public virtual Financiadora Financiadora { get; set; } = null!;

    [ForeignKey("InstalacaoId")]
    [InverseProperty("Financiamentos")]
    public virtual Instalacao Instalacao { get; set; } = null!;

    [InverseProperty("Financiamento")]
    public virtual ICollection<SolicitacaoIntervencao> SolicitacaoIntervencaos { get; } = new List<SolicitacaoIntervencao>();
}
