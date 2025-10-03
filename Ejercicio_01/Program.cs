using System;

class Temperaturas
{
    static void Main()
    {
        double[] temperaturasCelsius = solicitarTemperaturas(); // Obtener temperaturas por parte del usuario
        double[] temperaturasFahrenheit = convertirFahrenheit(temperaturasCelsius); // Convertir temperatus a fahrenheit

        Console.WriteLine("Temperaturas registradas:");
        mostrarTemperaturas(temperaturasCelsius, temperaturasFahrenheit); // Mostrar temperaturas

        Console.WriteLine("Estadisticas:");
        calcularEstadisticas(temperaturasCelsius); // Calcular y moestrar estadisticas
    }

    static double[] solicitarTemperaturas() // Metodo para pedir 7 temperaturas al usuario
    {
        double[] temperaturas = new double[7];

        Console.WriteLine("Ingresada las temperaturas registradas durante 7 dias en °C");

        for (int i = 0; i < temperaturas.Length; i++)
        {
            Console.WriteLine($"Dia {i + 1}:");
            while (!double.TryParse(Console.ReadLine(), out temperaturas[i])) // validar que se ingresa un numero
            {
                Console.WriteLine("Entrada no valida. Intente de nuevo:");
            }
        }

        return temperaturas;
    }

    static double[] convertirFahrenheit(double[] celsius) // Metodo para convertir cada temperatura de °C a °F
    {
        double[] fahrenheit = new double[celsius.Length];
        for (int i = 0; i < celsius.Length; i++)
        {
            fahrenheit[i] = (celsius[i] * 1.8) + 32; // formula para convertir de C a F
        }
        return fahrenheit;
    }

    static void mostrarTemperaturas(double[] celsius, double[] fahrenheit) // Metodo para mostrar temperaturas °C y °F en paralelo
    {
        Console.WriteLine("Dia\t°C\t°F");
        for (int i = 0; i < celsius.Length; i++)
        {
            Console.WriteLine($"{i + 1}\t{celsius[i]}°C\t\t{fahrenheit[i]:0.00}°F");
        }
    }

    static void calcularEstadisticas(double[] celsius) // Metodo para calcular y mostrar estadisticas de las temperaturas
    {
        double suma = 0;
        int diasSobre30 = 0;
        int diasBajoCero = 0;
        int diaMasFrio = 0;
        int diaMasCaluroso = 0;

        for (int i = 0; i < celsius.Length; i++)
        {
            double temp = celsius[i];
            suma += temp;

            if (temp > 30) diasSobre30++;
            if (temp < 0) diasBajoCero++;

            if (temp < celsius[diaMasFrio]) diaMasFrio = i;
            if (temp > celsius[diaMasCaluroso]) diaMasCaluroso = i;
        }

        double promedio = suma / celsius.Length;

        Console.WriteLine($"Temperatura promedio: {promedio:0.00}°C");
        Console.WriteLine($"Día más frío: Día {diaMasFrio + 1} con {celsius[diaMasFrio]}°C");
        Console.WriteLine($"Día más caluroso: Día {diaMasCaluroso + 1} con {celsius[diaMasCaluroso]}°C");
        Console.WriteLine($"Días por encima de 30°C: {diasSobre30}");
        Console.WriteLine($"Días bajo 0°C: {diasBajoCero}");
    }
}
