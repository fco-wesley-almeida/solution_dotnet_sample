using System.ComponentModel.DataAnnotations;

namespace CorteAutomatico.Core.Attributes;

public class VarcharMaxLengthAttribute: ValidationAttribute    
{
    private const int MaxLength = 100;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return IsValid(value)
            ? ValidationResult.Success
            : new ValidationResult($"Tamanho máximo do texto: {MaxLength}.");
    }
    
    public override bool IsValid(object? value)
    {
        string? str = value?.ToString()?.Trim();
        if (string.IsNullOrEmpty(str))
        {
            return true;
        }
        return str.Length <= MaxLength;
    }
}