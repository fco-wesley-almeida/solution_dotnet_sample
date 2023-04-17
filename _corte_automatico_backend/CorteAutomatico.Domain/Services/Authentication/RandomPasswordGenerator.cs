using System.Security.Cryptography;
using CorteAutomatico.Core.Modules.Authentication.Services;

namespace CorteAutomatico.Domain.Services.Authentication;

public class RandomPasswordGenerator: IRandomPasswordGenerator
{
    private const string AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
    private const int MinLength = 10;
    private const int MaxLength = 15;
    
    public string Generate()
    {
        int length = new Random().Next(MinLength, MaxLength + 1);
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        byte[] byteArray = new byte[length];
        rng.GetBytes(byteArray);
        var chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            int value = byteArray[i] % AllowedCharacters.Length;
            chars[i] = AllowedCharacters[value];
        }
        return new string(chars);
    }
}