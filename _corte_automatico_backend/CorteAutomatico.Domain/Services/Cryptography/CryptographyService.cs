using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using CorteAutomatico.Core.Modules.Cryptography;
using Microsoft.Extensions.Configuration;

namespace CorteAutomatico.Domain.Services.Cryptography;

public class CryptographyService: ICryptographyService
{
    private readonly string _key;

    public CryptographyService(IConfiguration configuration)
    {
        _key = configuration["Cryptography:Key"]!;
    }

    public string Encrypt<T>(T obj)
    {
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(_key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(JsonSerializer.Serialize(obj));
                    }
                    array = memoryStream.ToArray();
                }
            }
        }
        return Convert.ToBase64String(array);
    }

    public T Decrypt<T>(string encryptedObj)
    {
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(encryptedObj);
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_key);
        aes.IV = iv;
        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using MemoryStream memoryStream = new MemoryStream(buffer);
        using CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
        using StreamReader streamReader = new StreamReader((Stream)cryptoStream);
        return JsonSerializer.Deserialize<T>(streamReader.ReadToEnd()) ?? throw new InvalidOperationException();
    }
}