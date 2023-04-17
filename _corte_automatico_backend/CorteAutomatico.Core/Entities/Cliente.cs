using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("cliente")]
[Index("Uuid", Name = "uk_cliente_uuid", IsUnique = true)]
public partial class Cliente: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("financiadora_id")]
    public int FinanciadoraId { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Column("razao_social")]
    [StringLength(100)]
    public string? RazaoSocial { get; set; }

    [Column("nome_fantasia")]
    [StringLength(100)]
    public string? NomeFantasia { get; set; }

    [Column("numero_documento")]
    [StringLength(100)]
    public string NumeroDocumento { get; set; } = null!;

    [Column("tipo_documento_id")]
    public int TipoDocumentoId { get; set; }

    [Column("data_nascimento")]
    public DateOnly? DataNascimento { get; set; }

    [Column("nome_mae")]
    [StringLength(100)]
    public string? NomeMae { get; set; }

    [Column("telefone_1")]
    [StringLength(100)]
    public string? Telefone1 { get; set; }

    [Column("telefone_2")]
    [StringLength(100)]
    public string? Telefone2 { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("endereco_uf_estado")]
    [StringLength(100)]
    public string? EnderecoUfEstado { get; set; }

    [Column("endereco_cidade")]
    [StringLength(100)]
    public string? EnderecoCidade { get; set; }

    [Column("endereco_logradouro")]
    [StringLength(100)]
    public string? EnderecoLogradouro { get; set; }

    [Column("endereco_complemento")]
    [StringLength(100)]
    public string? EnderecoComplemento { get; set; }

    [Column("endereco_referencia")]
    [StringLength(100)]
    public string? EnderecoReferencia { get; set; }

    [Column("endereco_numero")]
    [StringLength(100)]
    public string? EnderecoNumero { get; set; }

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

    [Column("endereco_cep")]
    [StringLength(100)]
    public string? EnderecoCep { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<ClienteInstalacao> ClienteInstalacaos { get; } = new List<ClienteInstalacao>();

    [ForeignKey("FinanciadoraId")]
    [InverseProperty("Clientes")]
    public virtual Financiadora Financiadora { get; set; } = null!;

    [ForeignKey("TipoDocumentoId")]
    [InverseProperty("Clientes")]
    public virtual TipoDocumento TipoDocumento { get; set; } = null!;
}
