using System.ComponentModel.DataAnnotations;

namespace CorteAutomatico.Core.Modules.Authentication.Dtos;

public class LoginRequest
{
    [Required]
    public string Login { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}