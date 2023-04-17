using CorteAutomatico.Core.Modules.Jwt.Models;

namespace CorteAutomatico.Core.ApplicationModels.Command;

public class Command<T>: ICommand<T>
{
    public static CommandBuilder<T> Builder() => new();
    public JwtContext JwtContext { get; set; }
    public T Data { get; set; }
    public Command(T data, JwtContext jwtContext)
    {
        JwtContext = jwtContext ?? throw new ArgumentNullException(nameof(jwtContext));
        Data = data ?? throw new ArgumentNullException(nameof(data));
    }
}