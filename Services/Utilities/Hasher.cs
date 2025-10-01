using System.ComponentModel;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Services.Utilities;

public static class Hasher
{
    public static string HashPassword(string password, string salt)
    {
        const KeyDerivationPrf Pbkdf2prf = KeyDerivationPrf.HMACSHA1;
        const int Pbkdf2IterCount = 1000;
        const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits

        var saltBytes = Encoding.ASCII.GetBytes(salt);
        byte[] subkey = KeyDerivation.Pbkdf2(password, saltBytes, Pbkdf2prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

        var outputBytes = new byte[1 + saltBytes.Length + subkey.Length];
        outputBytes[0] = 0x00; // format marker
        Buffer.BlockCopy(saltBytes, 0, outputBytes, 1, salt.Length);
        Buffer.BlockCopy(subkey, 0, outputBytes, 1 + salt.Length, Pbkdf2SubkeyLength);
        return Encoding.UTF8.GetString(outputBytes);
    }
}