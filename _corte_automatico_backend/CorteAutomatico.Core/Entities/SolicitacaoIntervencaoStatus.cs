using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("solicitacao_intervencao_status")]
[Index("Uuid", Name = "uk_solicitacao_intervencao_status_uuid", IsUnique = true)]
public partial class SolicitacaoIntervencaoStatus: IEntity
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

    [InverseProperty("StatusAnteriorNavigation")]
    public virtual ICollection<SolicitacaoIntervencaoLog> SolicitacaoIntervencaoLogStatusAnteriorNavigations { get; } = new List<SolicitacaoIntervencaoLog>();

    [InverseProperty("StatusCorrenteNavigation")]
    public virtual ICollection<SolicitacaoIntervencaoLog> SolicitacaoIntervencaoLogStatusCorrenteNavigations { get; } = new List<SolicitacaoIntervencaoLog>();

    [InverseProperty("SolicitacaoIntervencaoStatus")]
    public virtual ICollection<SolicitacaoIntervencao> SolicitacaoIntervencaos { get; } = new List<SolicitacaoIntervencao>();
}
