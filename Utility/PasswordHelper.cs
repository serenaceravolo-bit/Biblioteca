namespace PasswordHelpers;

using System.Security.Cryptography;

public static class PasswordHelper
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterazioni = 100000;

    public static (string Hash, string Salt) CreaPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterazioni,
            HashAlgorithmName.SHA256,
            HashSize);

        return (
            Convert.ToBase64String(hash),
            Convert.ToBase64String(salt));
    }

    public static bool VerificaPassword(string passwordInserita, string hashSalvato, string saltSalvato)
    {
        byte[] salt = Convert.FromBase64String(saltSalvato);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            passwordInserita,
            salt,
            Iterazioni,
            HashAlgorithmName.SHA256,
            HashSize);

        return CryptographicOperations.FixedTimeEquals(
            hash,
            Convert.FromBase64String(hashSalvato));
    }

    
}
