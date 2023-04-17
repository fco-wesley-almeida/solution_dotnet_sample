namespace CorteAutomatico.Core.Exceptions;

public class BadRequestException: CustomException
{
    private readonly string _errorMessage;
    public override int StatusCode() => 400;

    public override string Message() => _errorMessage;

    public BadRequestException(string message): base(message)
    {
        _errorMessage = message;
    }
}