using System;

class sumarArreglos
{
    static void Main()
    {
        Console.WriteLine("Suma arreglos invertidos");

        int n = solicitarEntero(); // Solicitar al usuario cuantos elementos tendra cada arreglo

        Console.WriteLine("Ingrese ");
        int[] arreglo1 = solicitarArreglo(n, "Arreglo 2"); // Solicita el primer arreglo con validaciones

        Console.WriteLine("Ingrese e arreglo x");
        int[] arreglo2 = solicitarArreglo(n, "Arreglo 2"); // Solicitar el segundo arreglo con validaciones

        int[] resultado = sumarArreglosInvertidos(arreglo1, arreglo2); // Suma los arreglos, el segundo lo recorre de forma invertida tal y como lo pide el programa

        Console.WriteLine("Resultado de la suma");
        mostrarArreglo(resultado); // Muestra el arreglo resuelto
    }

    static int solicitarEntero()
    {
        int n;
        Console.WriteLine("Ingresa la cantidad de elementos que se crearan dentro del arreglo");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0) // Validacion breve que tiene que cumplir que no sea un caracter o menor a 0
        {
            Console.WriteLine("Entrada invalida, ingrese un numero entero mayor a 0");
        }
        return n; // retorna la cantidad valida
    }

    static int[] solicitarArreglo(int n, string nombre)
    {
        int[] arreglo = new int[n]; // Crea un arreglo del tamaño solicitido
        int limiteMin = -100;
        int limiteMax = 100;

        for (int i = 0; i < n; i++)
        {
            bool valido = false;
            while (!valido)
            {
                Console.Write($"{nombre} - Posición {i + 1}: ");
                string entrada = Console.ReadLine();
                int numero;

                if (int.TryParse(entrada, out numero))
                {
                    if (numero < limiteMin || numero > limiteMax) // Verifica si el numero esta dentro del rango
                    {
                        Console.WriteLine("Número fuera del rango (-100 a 100) intente otra vez.");
                    }
                    else if (existeArreglo(arreglo, numero, i)) // Verifica si ya fue ingresado
                    {
                        Console.WriteLine("Número repetido, ingrese un número diferente.");
                    }
                    else
                    {
                        arreglo[i] = numero; // Guarda el numero en la poscion correspondiente
                        valido = true; // Sale del bucle para contienuar al siguiente num
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida, ingrese un número entero.");
                }
            }
        }

        return arreglo; // Retorna el arreglo completo
    }

    static bool existeArreglo(int[] arreglo, int numero, int hastaPosicion)
    {
        for (int i = 0; i < hastaPosicion; i++)
        {
            if (arreglo[i] == numero)
            {
                return true; // el num ya existe
            }
        }
        return false; // no se encontro se acepta
    }

    static int[] sumarArreglosInvertidos(int[] a, int[] b)
    {
        int n = a.Length;
        int[] resultado = new int[n];

        for (int i = 0; i < n; i++)
        {
            resultado[i] = a[i] + b[n - 1 - i]; // b se recorre desde atras hacia adelante
        }

        return resultado;
    }

    static void mostrarArreglo(int[] arreglo)
    {
        Console.Write("Resultado: [");
        for (int i = 0; i < arreglo.Length; i++)
        {
            Console.Write(arreglo[i]);
            if (i < arreglo.Length - 1)
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}