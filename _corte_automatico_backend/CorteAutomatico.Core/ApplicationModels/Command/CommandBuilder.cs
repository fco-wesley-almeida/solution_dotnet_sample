using CorteAutomatico.Core.Modules.Jwt.Models;

namespace CorteAutomatico.Core.ApplicationModels.Command;

public class CommandBuilder<T>
{
    private T? _data;
    private JwtContext? _jwtContext;

    public CommandBuilder<T> SetData(T data)
    {
        _data = data;
        return this;
    }
    
    public CommandBuilder<T> SetJwtContext(JwtContext jwtContext)
    {
        _jwtContext = jwtContext;
        return this;
    }

    public Command<T> Build() => new Command<T>(_data!, _jwtContext!);
}