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
        public string ConvertirHash(string clave)
        {
            using var sha = SHA256.Create();
            byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(clave));
            string hashBase64 = Convert.ToBase64String(hashBytes);

            return hashBase64;
        }
       
    }
}
