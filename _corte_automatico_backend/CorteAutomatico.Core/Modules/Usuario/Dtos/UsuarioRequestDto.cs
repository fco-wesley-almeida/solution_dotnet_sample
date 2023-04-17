using System.ComponentModel.DataAnnotations;
using CorteAutomatico.Core.Attributes;

namespace CorteAutomatico.Core.Modules.Usuario.Dtos;

public class UsuarioRequestDto
{
    [Required, MaxLength] 
    public string Nome { get; set; } = null!;

    [Required, MaxLength] 
    public string Login { get; set; } = null!;

    [Required, MaxLength, EmailAddress] 
    public string Email { get; set; } = null!;
    
    [Required, MaxLength, Cpf]
    public string Cpf { get; set; } = null!;
    
    [Required]
    public Guid PerfilUuid { get; set; }
    
    [Required]
    public bool Ativo { get; set; }
    
    [Required]
    public bool EmailConfirmado { get; set; }
}