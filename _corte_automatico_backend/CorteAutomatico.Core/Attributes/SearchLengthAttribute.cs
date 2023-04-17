using System.ComponentModel.DataAnnotations;
using CorteAutomatico.Core.ApplicationModels;

namespace CorteAutomatico.Core.Attributes;

public class SearchLengthAttribute: ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        string? search = value as string;
        if (string.IsNullOrEmpty(search))
        {
            return true;
        }
        return search.Length is >= Search.MinLength and <= Search.MaxLength;
    }

    public override string FormatErrorMessage(string name) 
        => $"A busca deve ter, no mínimo {Search.MinLength}, e no máximo {Search.MaxLength} caracteres.";
}