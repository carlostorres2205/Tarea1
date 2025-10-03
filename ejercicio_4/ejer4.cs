using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Longitud de Cadenas ===");

        int n = LeerEnteroPositivo("Ingrese el número de nombres: ");

        string[] nombres = new string[n];
        int[] longitudes = new int[n];

        // Ingreso de nombres con validación
        for (int i = 0; i < n; i++)
        {
            nombres[i] = LeerNombreValido($"Ingrese el nombre {i + 1}: ");
            longitudes[i] = nombres[i].Length;
        }

        // Mostrar nombres y longitudes
        Console.WriteLine("\n--- Lista de nombres y longitudes ---");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{nombres[i]} - {longitudes[i]} letras");
        }

        // Clasificación
        Console.WriteLine("\n--- Clasificación por longitud ---");

        Console.WriteLine("Cortos (1-4 letras):");
        MostrarPorCategoria(nombres, longitudes, 1, 4);

        Console.WriteLine("\nMedios (5-7 letras):");
        MostrarPorCategoria(nombres, longitudes, 5, 7);

        Console.WriteLine("\nLargos (8 o más letras):");
        MostrarPorCategoria(nombres, longitudes, 8, int.MaxValue);
    }

    // Función para leer un entero positivo
    static int LeerEnteroPositivo(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            string input = Console.ReadLine();

            if (int.TryParse(input, out valor) && valor > 0)
            {
                return valor;
            }
            else
            {
                Console.WriteLine(" Error: Ingrese un número entero positivo.");
            }
        }
    }

    // Función para leer nombre válido
    static string LeerNombreValido(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string nombre = Console.ReadLine().Trim();

            if (nombre.Length <= 2)
            {
                Console.WriteLine(" Error: El nombre debe tener más de 2 caracteres.");
                continue;
            }

            if (!Regex.IsMatch(nombre, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine(" Error: El nombre solo debe contener letras, sin números ni símbolos.");
                continue;
            }

            return nombre;
        }
    }

    // Función para mostrar nombres según categoría
    static void MostrarPorCategoria(string[] nombres, int[] longitudes, int min, int max)
    {
        bool encontrado = false;
        for (int i = 0; i < nombres.Length; i++)
        {
            if (longitudes[i] >= min && longitudes[i] <= max)
            {
                Console.WriteLine($"{nombres[i]} ({longitudes[i]} letras)");
                encontrado = true;
            }
        }
        if (!encontrado) Console.WriteLine("Ninguno.");
    }
}