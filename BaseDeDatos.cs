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
            string linea = $"{servicio}|{usuario}|{claveCifrada}|{DateOnly.FromDateTime(DateTime.Now)}";
            File.AppendAllText(rutaClaves, linea + Environment.NewLine);
        }
        public List<Registro> listarClavesAlmacenadas()
        {
           var lista = new List<Registro>();

           if(!File.Exists(rutaClaves)) {
                return lista;
           }

           foreach (var registro in File.ReadAllLines(rutaClaves)) {
                var linea = registro.Split('|');
                if (linea.Length == 4) {
                    lista.Add(new Registro
                    {
                        Servicio = linea[0],
                        Usuaro_O_Emial = linea[1],
                        Fecha = linea[3].ToString()
                    });
                }
           }

           return lista;
        }
        public void EliminarClave(int fila)
        {
            List<string> lineas = File.ReadAllLines(rutaClaves).ToList();
            lineas.RemoveAt(fila);
            File.WriteAllLines(rutaClaves, lineas);
        }
    }
}
