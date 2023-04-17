using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("instalacao_arquivo")]
[Index("Uuid", Name = "uk_instalacao_arquivo_uuid", IsUnique = true)]
public partial class InstalacaoArquivo: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("instalacao_id")]
    public int InstalacaoId { get; set; }

    [Column("tipo_arquivo_id")]
    public int TipoArquivoId { get; set; }

    [Column("path_file")]
    public string PathFile { get; set; } = null!;

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

    [Column("titulo")]
    [StringLength(100)]
    public string Titulo { get; set; } = null!;

    [ForeignKey("InstalacaoId")]
    [InverseProperty("InstalacaoArquivos")]
    public virtual Instalacao Instalacao { get; set; } = null!;

    [ForeignKey("TipoArquivoId")]
    [InverseProperty("InstalacaoArquivos")]
    public virtual TipoArquivo TipoArquivo { get; set; } = null!;
}
