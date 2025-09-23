using System;
using GestorDeContraseñas;

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

        switch(opcion) {
            case "5":
                ConsolaCambiarContraseñaMaestra();
                break;
               
        }
    }
    
    static void ConsolaCambiarContraseñaMaestra()
    {
        Console.Clear();
        Console.Write("\n");
        Console.WriteLine("|=================================|");
        Console.WriteLine("|   CAMBIAR CONTRASEÑA MAESTRA    |");
        Console.WriteLine("|=================================|");
        string nuevaClave = "";
        string nuevaClaveConfirmacion = "";
        while (true)
        {
            Console.Write("\nIntoduce nueva contraseña maestra: ");
            nuevaClave = Console.ReadLine()!;
            Console.Write("\nConfirma nueva contraseña maestra: ");
            nuevaClaveConfirmacion = Console.ReadLine()!;

            if (nuevaClave != nuevaClaveConfirmacion)
            {
                Console.WriteLine("\nLas contraseñas no coinciden por favor vuelva a intentar.");
            }
            else
            {
                break;
            }
            
        }
        CriptografiaServicio servicio = new CriptografiaServicio(nuevaClave);
        BaseDeDatos baseDeDatos = new BaseDeDatos();
        string claveCifrada = servicio.EncryptString(nuevaClave);
        baseDeDatos.guardarClaveMaestra(claveCifrada);
        Console.WriteLine("\nContraña maestra actualizada correctamente.");
        Console.WriteLine("\nPresione 0 para volver al menú principal o enter para salir.");
        string opción = Console.ReadLine()!;
        if (opción == "0")
        {
            MostrarMenuPrincipal();
        }
        else
        {
            Console.ReadKey();
        }
    }
       
    


}