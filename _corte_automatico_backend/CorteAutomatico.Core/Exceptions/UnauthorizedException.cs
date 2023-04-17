namespace CorteAutomatico.Core.Exceptions;

public class UnauthorizedException: CustomException
{
    public override int StatusCode() => 401;

    public override string Message() => "Acesso não autorizado.";
}