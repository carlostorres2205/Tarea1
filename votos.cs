using System;

class Programa
{
    static void Main(string[] args)
    {
        // Generar votos aleatorios
        Random aleatorio = new Random();
        int[] votos = new int[100];
        for (int i = 0; i < 100; i++)
        {
            votos[i] = aleatorio.Next(1, 6); // Número aleatorio entre 1 y 5
        }

        // Procesar votos
        int[] conteoVotos = new int[5]; // Índice 0-4 para candidatos 1-5
        int votosInvalidos = 0;

        foreach (int voto in votos)
        {
            if (voto >= 1 && voto <= 5)
            {
                conteoVotos[voto - 1]++;
            }
            else
            {
                votosInvalidos++;
            }
        }

        // bloque para encontrar ganador 
        int votosMaximos = 0;
        int indiceGanador = 0;
        bool empate = false;
        for (int i = 0; i < 5; i++)
        {
            if (conteoVotos[i] > votosMaximos)
            {
                votosMaximos = conteoVotos[i];
                indiceGanador = i + 1;
                empate = false;
            }
            else if (conteoVotos[i] == votosMaximos && conteoVotos[i] != 0)
            {
                empate = true;
            }
        }

        // Calcular porcentajes
        int totalVotosValidos = 100 - votosInvalidos;
        double[] porcentajes = new double[5];
        for (int i = 0; i < 5; i++)
        {
            porcentajes[i] = totalVotosValidos > 0 ? (double)conteoVotos[i] / totalVotosValidos * 100 : 0;
        }

        // Mostrar resultados
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Resultados de la votación:");
        Console.WriteLine(new string('-', 50));
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Candidato {i + 1}: {conteoVotos[i]} votos ({porcentajes[i]:F2}%)");
        }
        Console.WriteLine($"\nTotal votos inválidos: {votosInvalidos}");
        Console.WriteLine($"\nGanador(es):");
        if (empate)
        {
            for (int i = 0; i < 5; i++)
            {
                if (conteoVotos[i] == votosMaximos)
                {
                    Console.WriteLine($"Candidato {i + 1} con {votosMaximos} votos\n");
                }
            }
        }
        else
        {
            Console.WriteLine($"Candidato {indiceGanador} con {votosMaximos} votos");
        }
    }
}