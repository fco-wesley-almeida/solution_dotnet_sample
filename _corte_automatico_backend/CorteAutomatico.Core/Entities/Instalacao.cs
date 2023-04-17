using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("instalacao")]
[Index("Uuid", Name = "uk_instalacao_uuid", IsUnique = true)]
public partial class Instalacao: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Column("endereco_uf_estado")]
    [StringLength(100)]
    public string EnderecoUfEstado { get; set; } = null!;

    [Column("endereco_cidade")]
    [StringLength(100)]
    public string EnderecoCidade { get; set; } = null!;

    [Column("endereco_logradouro")]
    [StringLength(100)]
    public string EnderecoLogradouro { get; set; } = null!;

    [Column("endereco_complemento")]
    [StringLength(100)]
    public string EnderecoComplemento { get; set; } = null!;

    [Column("endereco_referencia")]
    [StringLength(100)]
    public string EnderecoReferencia { get; set; } = null!;

    [Column("endereco_numero")]
    [StringLength(100)]
    public string EnderecoNumero { get; set; } = null!;

    [Column("endereco_cep")]
    [StringLength(100)]
    public string EnderecoCep { get; set; } = null!;

    [Column("obs")]
    [StringLength(100)]
    public string? Obs { get; set; }

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

    [Column("instalacao_status_id")]
    public int InstalacaoStatusId { get; set; }

    [InverseProperty("Instalacao")]
    public virtual ICollection<ClienteInstalacao> ClienteInstalacaos { get; } = new List<ClienteInstalacao>();

    [InverseProperty("Instalacao")]
    public virtual ICollection<DispositivoInstalacao> DispositivoInstalacaos { get; } = new List<DispositivoInstalacao>();

    [InverseProperty("Instalacao")]
    public virtual ICollection<Financiamento> Financiamentos { get; } = new List<Financiamento>();

    [InverseProperty("Instalacao")]
    public virtual ICollection<InstalacaoArquivo> InstalacaoArquivos { get; } = new List<InstalacaoArquivo>();

    [InverseProperty("Instalacao")]
    public virtual ICollection<InstalacaoIntegrador> InstalacaoIntegradors { get; } = new List<InstalacaoIntegrador>();

    [ForeignKey("InstalacaoStatusId")]
    [InverseProperty("Instalacaos")]
    public virtual InstalacaoStatus InstalacaoStatus { get; set; } = null!;
}
