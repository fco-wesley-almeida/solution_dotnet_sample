using System.ComponentModel.DataAnnotations;
using CorteAutomatico.Core.ApplicationModels;

namespace CorteAutomatico.Core.Attributes;

public class CpfAttribute: ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        string? cpf = (string?) value;
        return cpf is not null && DocumentValidation.Validate.ValidateCpf(cpf);
    }

    public override string FormatErrorMessage(string name) 
        => $"Informe um CPF válido.";
}