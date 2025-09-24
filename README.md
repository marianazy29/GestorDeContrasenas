# Gestor de Claves con C# y .NET 8

Este proyecto es una aplicación de consola desarrollada en **C#** con
**.NET 8**, permite gestionar claves de forma sencilla.
Se utilizan algoritmos criptográficos (AES), (SHA-256) para proteger la información
y archivos de texto (.txt) para almacenar los registros.
------------------------------------------------------------------------

##  Cómo ejecutar la aplicación

1.  Clonar el repositorio desde GitHub:

    **https://github.com/marianazy29/GestorDeContrasenas.git**

2.  Abrir el proyecto en **Visual Studio 2022**.

3.  Ejecutar el programa.

------------------------------------------------------------------------

## Dependencias

-   **.NET 8.0 SDK**
    Necesario para compilar y ejecutar el proyecto.
    Descargar desde: <https://dotnet.microsoft.com/download>

-   **System.Security.Cryptography**
    Biblioteca incluida en .NET para cifrado AES.

-   **Git**
    Para clonar y versionar el proyecto.

------------------------------------------------------------------------

## Descripción general

La aplicación permite:
*  El usuario propietario, podrá establecer una contraseña maestra para
   la encriptación de su información.
*  La contraseña maestra estará cifrada con el algoritmo **SHA-256**.
*  Registrar claves (servicio, usuario, contraseña, fecha de creación). 
*  Cifrar contraseñas con **AES-256**.
*  Listar las claves.
*  Almacenamiento en un archivo de texto.
*  Eliminar registros existentes.
*  Recuperar y mostrar datos en consola en un formato tabular.

Se eligió un enfoque sencillo para el almacenamiento (`.txt`) a fin de
facilitar el aprendizaje de los conceptos básicos de cybersecurity.

------------------------------------------------------------------------

## Tecnologías y herrameintas empleadas
* Visual Studio 2022.
* Lenguaje de programación C#.
* .NET 8.
* AES-256 (CBC,PKCS7).
* SHA-256
* Librería System.Security.Cryptograpy

------------------------------------------------------------------------

## Autor

Mariana Zúñiga Yáñez.
