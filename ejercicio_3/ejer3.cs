using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine(" Intercalar Arreglos ");

        int n = LeerEnteroPositivo("Ingrese el número de elementos de cada arreglo: ");

        int[] arr1 = new int[n];
        int[] arr2 = new int[n];

        Console.WriteLine("\n--- Ingreso de datos para arr1 ---");
        for (int i = 0; i < n; i++)
        {
            arr1[i] = LeerEnteroPositivo($"arr1[{i}] = ");
        }

        Console.WriteLine("\n--- Ingreso de datos para arr2 ---");
        for (int i = 0; i < n; i++)
        {
            arr2[i] = LeerEnteroPositivo($"arr2[{i}] = ");
        }

        // Crear arreglo intercalado
        int[] resultado = new int[n * 2];
        for (int i = 0, j = 0; i < n; i++)
        {
            resultado[j++] = arr1[i];
            resultado[j++] = arr2[i];
        }

        Console.WriteLine("\nArreglo intercalado:");
        Console.WriteLine("[" + string.Join(", ", resultado) + "]");

        // Identificar origen
        Console.WriteLine("\nOrigen de cada valor:");
        for (int i = 0; i < resultado.Length; i++)
        {
            string origen = (i % 2 == 0) ? "arr1" : "arr2";
            Console.WriteLine($"{resultado[i]} ({origen})");
        }
    }

    // Función para validar entrada
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
}