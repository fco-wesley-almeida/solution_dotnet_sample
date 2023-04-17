using System.Security.Cryptography.Xml;

namespace CorteAutomatico.Core.Modules.Cryptography;

public interface ICryptographyService
{
    string Encrypt<T>(T obj);
    T Decrypt<T>(string encryptedObj);
}