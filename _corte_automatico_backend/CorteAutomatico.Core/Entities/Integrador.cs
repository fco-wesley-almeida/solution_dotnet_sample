using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("integrador")]
[Index("Uuid", Name = "uk_integrador_uuid", IsUnique = true)]
public partial class Integrador: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("nome_fantasia")]
    [StringLength(100)]
    public string NomeFantasia { get; set; } = null!;

    [Column("razao_social")]
    [StringLength(100)]
    public string RazaoSocial { get; set; } = null!;

    [Column("cnpj")]
    [StringLength(100)]
    public string Cnpj { get; set; } = null!;

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

    [InverseProperty("Integrador")]
    public virtual ICollection<ColaboradorIntegrador> ColaboradorIntegradors { get; } = new List<ColaboradorIntegrador>();

    [InverseProperty("Integrador")]
    public virtual ICollection<InstalacaoIntegrador> InstalacaoIntegradors { get; } = new List<InstalacaoIntegrador>();

    [InverseProperty("Integrador")]
    public virtual ICollection<IntegradorPerfil> IntegradorPerfils { get; } = new List<IntegradorPerfil>();
}
