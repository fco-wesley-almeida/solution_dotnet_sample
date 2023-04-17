namespace CorteAutomatico.Core.Exceptions;

public class ForbiddenException: CustomException
{
    public override int StatusCode() => 403;

    public override string Message() => "Acesso negado para esse recurso";
}