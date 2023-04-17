using System.ComponentModel.DataAnnotations;
using CorteAutomatico.Core.Attributes;

namespace CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;

public class DispositivoModeloRequestDto
{
    [Required]
    [VarcharMaxLength]
    public string Nome { get; set; } = null!;
    
    [Required]
    public Guid DispositivoMarcaUuid { get; set; }      
    
    [Required]
    public bool Compativel { get; set; }
    
    [Required]
    public int QuantidadeFases { get; set; }
    
    [Required]
    public bool Ativo { get; set; }
}