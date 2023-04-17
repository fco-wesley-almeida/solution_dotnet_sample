using System.ComponentModel.DataAnnotations;
using CorteAutomatico.Core.Attributes;

namespace CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;

public class TipoDispositivoRequestDto
{
    [Required]
    [VarcharMaxLength]
    public string Nome { get; set; } = null!;
    [Required]
    public bool Ativo { get; set; }
}