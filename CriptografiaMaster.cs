using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeContraseñas
{
    public class CriptografiaMaster
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("Tja-UCB@2025*_!/");

        public string EncryptString(string plain)
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.GenerateIV();

            using var encryptor = aes.CreateEncryptor();
            var plainBytes = Encoding.UTF8.GetBytes(plain);
            var cipher = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            var outBytes = new byte[aes.IV.Length + cipher.Length];
            Buffer.BlockCopy(aes.IV, 0, outBytes, 0, aes.IV.Length);
            Buffer.BlockCopy(cipher, 0, outBytes, aes.IV.Length, cipher.Length);

            return Convert.ToBase64String(outBytes);
        }

        public string DecryptString(string base64)
        {
            var full = Convert.FromBase64String(base64);

            using var aes = Aes.Create();
            aes.Key = Key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var iv = new byte[aes.BlockSize / 8];
            var cipher = new byte[full.Length - iv.Length];
            Buffer.BlockCopy(full, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(full, iv.Length, cipher, 0, cipher.Length);
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            var plain = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);

            return Encoding.UTF8.GetString(plain);
        }
    }
}
