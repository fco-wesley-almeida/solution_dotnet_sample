namespace CorteAutomatico.Core.Exceptions;

public class NotFoundException: CustomException
{
    public override int StatusCode() => 404;

    public override string Message() => "Registro não encontrado.";
}