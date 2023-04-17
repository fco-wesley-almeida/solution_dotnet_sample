using System.Security;
using CorteAutomatico.Core.Exceptions;

namespace CorteAutomatico.Core.ApplicationModels;

public class EnvironmentVar
{
    private readonly string _value;
    public EnvironmentVar(string variable)
    {
        variable = variable.Trim();
        if (string.IsNullOrEmpty(variable))
        {
            throw new ArgumentNullException(nameof(variable));
        }
        try
        {
            _value = Environment.GetEnvironmentVariable(variable) 
                  ?? throw new InvalidEnvironmentVarException($"Env {variable} is undefined.");
        }
        catch (SecurityException e)
        {
            throw new InvalidEnvironmentVarException($"Security error on trying to access Env {variable}: {e.Message}");
        }
    }
    
    public override string ToString() => _value;
}