using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeContraseñas
{
    public class BaseDeDatos
    {
        string rutaClaveMaestra = @"D:\BD\claveMaestra.txt";
        string rutaClaves = @"D:\BD\claves.txt";
        public void guardarClaveMaestra(string claveCifrada)
        {
            System.IO.File.WriteAllText(rutaClaveMaestra, claveCifrada);
           
        }
        public string recuperarClaveMaestra()
        {
            string claveCifrada = File.ReadAllText(rutaClaveMaestra);
            return claveCifrada;

        }
        public void guardarNuevaClave(string servicio, string usuario, string claveCifrada)
        {
            string linea = $"{servicio}|{usuario}|{claveCifrada}";
            File.AppendAllText(rutaClaves, linea + Environment.NewLine);
        }

        public void listarClavesAlmacenadas()
        {
           
        }
    }
}
