using System.Reflection.Metadata;
using System;
namespace CorteAutomatico.Core.Exceptions;

public abstract class CustomException: Exception
{
    protected CustomException()
    {
    }

    protected CustomException(string? message) : base(message)
    {
    }

    public abstract int StatusCode();
    public new abstract string Message();

    public object Response()
    {
        return new
        {
            StatusCode = StatusCode(),
            Message = Message()
        };
    }
}