using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeContraseñas
{
    public class BaseDeDatos
    {
        string ruta = @"D:\BD\claveMaestra.txt";
        public void guardarClaveMaestra(string claveCifrada)
        {
            System.IO.File.WriteAllText(ruta, claveCifrada);
           
        }
    }
}
