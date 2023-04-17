using CorteAutomatico.Core.Modules.Jwt.Models;

namespace CorteAutomatico.Core.ApplicationModels.Command;

public interface ICommand<T>
{
    public JwtContext JwtContext { get; set; }
    public T Data { get; set; }
}