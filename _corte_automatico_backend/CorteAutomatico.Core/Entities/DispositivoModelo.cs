using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorteAutomatico.Core.Entities;

[Table("dispositivo_modelo")]
[Index("Uuid", Name = "uk_dispositivo_modelo_uuid", IsUnique = true)]
public partial class DispositivoModelo: IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [Column("dispositivo_marca_id")]
    public int DispositivoMarcaId { get; set; }

    [Column("compativel")]
    public bool Compativel { get; set; }

    [Column("quantidade_fases")]
    public int QuantidadeFases { get; set; }

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

    [ForeignKey("DispositivoMarcaId")]
    [InverseProperty("DispositivoModelos")]
    public virtual DispositivoMarca DispositivoMarca { get; set; } = null!;

    [InverseProperty("DispositivoModelo")]
    public virtual ICollection<Dispositivo> Dispositivos { get; } = new List<Dispositivo>();
}
