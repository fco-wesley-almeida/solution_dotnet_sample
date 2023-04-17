using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CorteAutomatico.Core.Attributes;

public class PasswordAttribute: ValidationAttribute    
{
    private const int MinLength = 8;
    private const int MaxLength = 100;
    private const string LowerCaseRegex = @"[abcdefghijklmnopqrstuvwxyz]";
    private const string UpperCaseRegex = @"[ABCDEFGHIJKLMNOPQRSTUVWXYZ]";
    private const string NumbersRegex = @"\d";
    private const string SimbolsRegex = @"[@#+=,.*!$%^&()[\]{}<>?~_-|;]";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return IsValid(value)
            ? ValidationResult.Success
            : new ValidationResult("Informe uma senha válida.");
    }
    
    public override bool IsValid(object? value)
    {
        string? password = value?.ToString()?.Trim();
        if (string.IsNullOrEmpty(password) || password.Length is < MinLength or > MaxLength)
        {
            return false;
        }
        var patterns = new List<string>
        {
            LowerCaseRegex,
            UpperCaseRegex,
            NumbersRegex,
            SimbolsRegex
        };
        return patterns.All(pattern => Regex.IsMatch(password, pattern));
    }
    // TODO: Colocar uma mensagem mais descritiva para o erro de senha
}