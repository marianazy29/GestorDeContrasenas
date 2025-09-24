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
            case "1":
                ConsolaAgregarContraseña();
                break;
            case "2":
                ConsolaVerContraseñasAlmacenadas();
                break;
            case "4":
                ConsolaEliminarContraseña();
                break;
            case "5":
                ConsolaCambiarContraseñaMaestra();
                break;
            case "6":
                Salir();
                break;

        }
    }

    static void ConsolaAgregarContraseña()
    {
        Console.Clear();
        Console.Write("\n");
        Console.WriteLine("|=================================|");
        Console.WriteLine("|       AGREGAR CONTRASEÑA        |");
        Console.WriteLine("|=================================|");
        Console.Write("\nIngrese el nombre del serivicio: ");
        string servicio = Console.ReadLine();

        Console.Write("\nIngrese usuario o email: ");
        string usuarioOEmail = Console.ReadLine();

        string clave = "";
        string claveConfirmacion = "";
        while (true)
        {
            Console.Write("\nIngrese contraseña: ");
            clave = OcultarClave();
            Console.Write("\nConfirme contraseña: ");
            claveConfirmacion = OcultarClave();

            if (clave != claveConfirmacion)
            {
                Console.WriteLine("\nLas contraseñas no coinciden por favor vuelva a intentar.");
            }
            else
            {
                break;
            }
        }
       
        BaseDeDatos baseDeDatos = new BaseDeDatos();
        CriptografiaMaster criptografiaMaster = new CriptografiaMaster();
        CriptografiaServicio criotografiaServicio = new CriptografiaServicio(criptografiaMaster.DecryptString(baseDeDatos.recuperarClaveMaestra()));
        baseDeDatos.guardarNuevaClave(criotografiaServicio.EncryptString(servicio), criotografiaServicio.EncryptString(usuarioOEmail), criotografiaServicio.EncryptString(clave));

        Console.WriteLine("\nContraseña guardada exitosamente para " + servicio);
        Console.WriteLine("\nPresione cualquier tecla para volver al menú principal.");
        Console.ReadKey(true);
        MostrarMenuPrincipal();
    }

    static void ConsolaVerContraseñasAlmacenadas()
    {
        Console.Clear();
        Console.Write("\n");
        Console.WriteLine("|===========================================================================|");
        Console.WriteLine("|                           CONTRASEÑAS ALMACENADAS                         |");
        Console.WriteLine("|===========================================================================|");
        Console.Write("\n");        
        ListarClaves();
        Console.WriteLine("\nPresione cualquier tecla para volver al menú principal.");
        Console.ReadKey(true);
        MostrarMenuPrincipal();
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
            Console.Write("\nIngrese nueva contraseña maestra: ");
            nuevaClave = OcultarClave();
            Console.Write("\nConfirme nueva contraseña maestra: ");
            nuevaClaveConfirmacion = OcultarClave();

            if (nuevaClave != nuevaClaveConfirmacion)
            {
                Console.WriteLine("\nLas contraseñas no coinciden por favor vuelva a intentar.");
            }
            else
            {
                break;
            }
            
        }
        CriptografiaMaster criptografiaMaster = new CriptografiaMaster();
        BaseDeDatos baseDeDatos = new BaseDeDatos();
        string claveCifrada = criptografiaMaster.EncryptString(nuevaClave);
        baseDeDatos.guardarClaveMaestra(claveCifrada);
        Console.WriteLine("\nContraña maestra actualizada correctamente.");
        Console.WriteLine("\nPresione cualquier tecla para volver al menú principal.");
        Console.ReadKey(true);
        MostrarMenuPrincipal();
    }
    static void ConsolaEliminarContraseña()
    {
        Console.Clear();
        Console.Write("\n");
        Console.WriteLine("|===========================================================================|");
        Console.WriteLine("|                             ELIMINAR CONTRASEÑA                           |");
        Console.WriteLine("|===========================================================================|");
        Console.Write("\n");
        ListarClaves();      
        while (true) {
            Console.Write("\nSeleccione un número para eliminar contraseña o 0 para volver: ");
            int numero = int.Parse(Console.ReadLine()!);
            if (numero != 0) {
                BaseDeDatos _baseDeDatos = new BaseDeDatos();
                _baseDeDatos.EliminarClave(numero - 1);
                ListarClaves();
            }
            else { break;  }
        }
        MostrarMenuPrincipal();
       

    }

    static string OcultarClave()
    {
        string clave = "";
        ConsoleKeyInfo tecla;

        do
        {
            tecla = Console.ReadKey(intercept: true); 
            if (tecla.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }
            else if (tecla.Key == ConsoleKey.Backspace)
            {
                if (clave.Length > 0)
                {
                    clave = clave.Substring(0, clave.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else
            {
                clave += tecla.KeyChar;
                Console.Write("*");
            }

        } while (true);

        return clave;
    }

    static void ListarClaves()
    {
        BaseDeDatos baseDeDatos = new BaseDeDatos();
        CriptografiaMaster criptografiaMaster = new CriptografiaMaster();
        CriptografiaServicio criotografiaServicio = new CriptografiaServicio(criptografiaMaster.DecryptString(baseDeDatos.recuperarClaveMaestra()));
        var registros = baseDeDatos.listarClavesAlmacenadas();
        int count = 0;
        Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-15}", "N°", "SERVICIO", "USUARIO", "FECHA");
        Console.WriteLine("----------------------------------------------------------------------------");
        foreach (var r in registros)
        {
            var servicio = criotografiaServicio.DecryptString(r.Servicio);
            var usuarioEmail = criotografiaServicio.DecryptString(r.Usuaro_O_Emial);
            var fecha = r.Fecha;
            Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-15}", count += 1, servicio, usuarioEmail, fecha);
        }
        Console.WriteLine("-----------------------------------------------------------------------------");
    }
    static void Salir()
    {
        Console.ReadKey(true);
    }

}