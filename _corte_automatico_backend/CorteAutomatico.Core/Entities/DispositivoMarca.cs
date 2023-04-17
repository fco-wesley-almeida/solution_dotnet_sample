using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("dispositivo_marca")]
[Index("Uuid", Name = "uk_dispositivo_marca_uuid", IsUnique = true)]
public partial class DispositivoMarca: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [Column("tipo_dispositivo_id")]
    public int TipoDispositivoId { get; set; }

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

    [InverseProperty("DispositivoMarca")]
    public virtual ICollection<DispositivoModelo> DispositivoModelos { get; } = new List<DispositivoModelo>();

    [ForeignKey("TipoDispositivoId")]
    [InverseProperty("DispositivoMarcas")]
    public virtual TipoDispositivo TipoDispositivo { get; set; } = null!;
}
