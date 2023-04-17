using System.ComponentModel.DataAnnotations;
using CorteAutomatico.Core.Attributes;

namespace CorteAutomatico.Core.Modules.Perfil.Dtos;

public class PerfilRequestDto
{
    [Required]
    [VarcharMaxLength]
    public string Nome { get; set; } = null!;
    [Required]
    public bool Ativo { get; set; }
}