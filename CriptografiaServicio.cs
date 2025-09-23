using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeContraseñas
{
    public class CriptografiaServicio
    {
        private readonly byte[] _key;
      
        public CriptografiaServicio(string claveMaestra)
        {
           
            using var sha = System.Security.Cryptography.SHA256.Create();
            _key = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(claveMaestra));
        }

        public string EncryptString(string plain)
        {
            using var aes = System.Security.Cryptography.Aes.Create();
            aes.Key = _key;
            aes.Mode = System.Security.Cryptography.CipherMode.CBC;
            aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            aes.GenerateIV();

            using var encryptor = aes.CreateEncryptor();
            var plainBytes = System.Text.Encoding.UTF8.GetBytes(plain);
            var cipher = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            var outBytes = new byte[aes.IV.Length + cipher.Length];
            Buffer.BlockCopy(aes.IV, 0, outBytes, 0, aes.IV.Length);
            Buffer.BlockCopy(cipher, 0, outBytes, aes.IV.Length, cipher.Length);

            return Convert.ToBase64String(outBytes);
        }

        public string DecryptString(string base64)
        {
            var full = Convert.FromBase64String(base64);

            using var aes = System.Security.Cryptography.Aes.Create();
            aes.Key = _key;
            aes.Mode = System.Security.Cryptography.CipherMode.CBC;
            aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            var iv = new byte[aes.BlockSize / 8];
            var cipher = new byte[full.Length - iv.Length];
            Buffer.BlockCopy(full, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(full, iv.Length, cipher, 0, cipher.Length);
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            var plain = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);

            return System.Text.Encoding.UTF8.GetString(plain);
        }
    }
}
