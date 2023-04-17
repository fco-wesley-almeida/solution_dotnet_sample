namespace CorteAutomatico.Core.Exceptions;

public class InvalidEnvironmentVarException: Exception
{
    public InvalidEnvironmentVarException(string? message) : base(message)
    {
    }
}