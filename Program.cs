using System;

class Program
{
    static void Main()
    {
       
        Console.Title = "Gestor de Contraseñas";
        MostrarMenuPrincipal();
    }

    static void MostrarMenuPrincipal()
    {
        Console.Clear();
        Console.Write("\n");
        Console.WriteLine("|=================================|");
        Console.WriteLine("|       GESTOR DE CONTRASEÑAS     |");
        Console.WriteLine("|          MENÚ PRINCIPAL         |");
        Console.WriteLine("|=================================|");
        Console.Write("\n");
        Console.WriteLine("[1] Agregar nueva contraseña.");
        Console.WriteLine("[2] Ver contraseñas almacenadas.");
        Console.WriteLine("[3] Buscar contraseñas por servicio.");
        Console.WriteLine("[4] Eliminar contraseña");
        Console.WriteLine("[5] Cambiar contraseña maestra.");
        Console.WriteLine("[6] Salir.");

        Console.Write("\nSeleccione una opción: ");
        string opcion = Console.ReadLine()!;

        
    }

   
}