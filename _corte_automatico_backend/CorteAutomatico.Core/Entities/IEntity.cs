using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorteAutomatico.Core.Entities;

public interface IEntity
{
    public int Id { get; set; }
    public Guid Uuid { get; set; }
    public string CriadoPor { get; set; }
    public DateTime CriadoEm { get; set; }
    public string ModificadoPor { get; set; }
    public DateTime ModificadoEm { get; set; }
    public bool Ativo { get; set; }
}