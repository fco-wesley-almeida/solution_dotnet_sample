using System.ComponentModel.DataAnnotations;
using CorteAutomatico.Core.Attributes;

namespace CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;

public class DispositivoMarcaRequestDto
{
    [Required] [VarcharMaxLength] public string Nome { get; set; } = null!;

    [Required] public bool Ativo { get; set; }

    [Required] public Guid TipoDispositivoUuid { get; set; }
}