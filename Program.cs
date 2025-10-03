//Reto 5: Gestión de turnos en una clínica
//Enunciado:
//Una clínica asigna 20 turnos diarios. Los pacientes se registran con su edad. El objetivo es analizar la distribución de edades.
//Problema a resolver:
//1.	Ingresar las edades de 20 pacientes.
//2.	Clasificar en grupos:
//•	Niños (0–12)
//•	Jóvenes (13–25)
//•	Adultos (26–60)
//•	Mayores (>60)
//3.	Mostrar cuántos hay en cada grupo.
//4.	Detectar si hay más de 5 personas mayores (alerta por alto riesgo).
//5.	Calcular la edad promedio general y por grupo.

using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionTurnosClinica
{
    class Program
    {
        // Rangos de grupos
        enum Grupo { Ninos, Jovenes, Adultos, Mayores }

        static void Main(string[] args)
        {
            const int CUPOS_DIARIOS = 20;

            List<int> edades = new List<int>(CUPOS_DIARIOS);

            Console.WriteLine("=== Gestión de turnos (20 pacientes) ===");
            Console.WriteLine("Ingresa la edad de cada paciente (0 a 120).");
            Console.WriteLine("-----------------------------------------");

            for (int i = 1; i <= CUPOS_DIARIOS; i++)
            {
                int edad = LeerEdadValida($"Edad del paciente #{i}: ");
                edades.Add(edad);
            }

            // Clasificación por grupos
            var grupos = new Dictionary<Grupo, List<int>>
            {
                { Grupo.Ninos,   new List<int>() },   // 0–12
                { Grupo.Jovenes, new List<int>() },   // 13–25
                { Grupo.Adultos, new List<int>() },   // 26–60
                { Grupo.Mayores, new List<int>() }    // >60
            };

            foreach (var edad in edades)
            {
                grupos[DeterminarGrupo(edad)].Add(edad);
            }

            // Resultados
            Console.WriteLine("\n=== Resultados ===");

            // 3) Conteos por grupo
            ImprimirConteos(grupos);

            // 4) Alerta por alto riesgo
            int cantMayores = grupos[Grupo.Mayores].Count;
            if (cantMayores > 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ALERTA: Hay más de 5 personas mayores (>60) registradas hoy.");
                Console.ResetColor();
            }

            // 5) Promedios
            double promedioGeneral = edades.Count > 0 ? edades.Average() : 0;
            Console.WriteLine($"\nEdad promedio GENERAL: {promedioGeneral:F2} años");

            Console.WriteLine("Edad promedio por grupo:");
            ImprimirPromedioGrupo("Niños (0–12)", grupos[Grupo.Ninos]);
            ImprimirPromedioGrupo("Jóvenes (13–25)", grupos[Grupo.Jovenes]);
            ImprimirPromedioGrupo("Adultos (26–60)", grupos[Grupo.Adultos]);
            ImprimirPromedioGrupo("Mayores (>60)", grupos[Grupo.Mayores]);

            Console.WriteLine("\nProceso finalizado. Presiona una tecla para salir...");
            Console.ReadKey();
        }

        // --- AYUDAS---

        static int LeerEdadValida(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int edad) && edad >= 0 && edad <= 120)
                    return edad;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada inválida. Ingresa un número entero entre 0 y 120.");
                Console.ResetColor();
            }
        }

        static Grupo DeterminarGrupo(int edad)
        {
            if (edad <= 12) return Grupo.Ninos;
            if (edad <= 25) return Grupo.Jovenes;
            if (edad <= 60) return Grupo.Adultos;
            return Grupo.Mayores;
        }

        static void ImprimirConteos(Dictionary<Grupo, List<int>> grupos)
        {
            Console.WriteLine("Conteo por grupo:");
            Console.WriteLine($"- Niños (0–12): {grupos[Grupo.Ninos].Count}");
            Console.WriteLine($"- Jóvenes (13–25): {grupos[Grupo.Jovenes].Count}");
            Console.WriteLine($"- Adultos (26–60): {grpos(grupos, Grupo.Adultos)}"); // <- evitamos error de tipeo
            Console.WriteLine($"- Mayores (>60): {grupos[Grupo.Mayores].Count}");
        }

        static int grpos(Dictionary<Grupo, List<int>> grupos, Grupo g) => grupos[g].Count;

        static void ImprimirPromedioGrupo(string titulo, List<int> edades)
        {
            if (edades.Count == 0)
            {
                Console.WriteLine($"- {titulo}: s/d (sin datos)");
            }
            else
            {
                Console.WriteLine($"- {titulo}: {edades.Average():F2} años");
            }
        }
    }
}

