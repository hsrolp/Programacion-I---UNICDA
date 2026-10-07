using System;
using System.Collections.Generic;

class Estudiante
{
    // Datos del estudiante
    public string Nombre;
    public string Apellido;

    // Cuatro notas
    public double Nota1;
    public double Nota2;
    public double Nota3;
    public double Nota4;

    // Resultado
    public double Promedio;
    public string Literal;
}

class Ejercicio2
{
    static void Main()
    {
        // Lista donde guardaremos todos los estudiantes
        List<Estudiante> estudiantes = new List<Estudiante>();

        string continuar = "S";

        // Se repite mientras el usuario quiera agregar estudiantes
        while (continuar.ToUpper() == "S")
        {
            Estudiante estudiante = new Estudiante();

            // Pedimos los datos del estudiante
            Console.Write("\nNombre: ");
            estudiante.Nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            estudiante.Apellido = Console.ReadLine();

            // Pedimos las cuatro notas
            Console.Write("Nota 1: ");
            estudiante.Nota1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nota 2: ");
            estudiante.Nota2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nota 3: ");
            estudiante.Nota3 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nota 4: ");
            estudiante.Nota4 = Convert.ToDouble(Console.ReadLine());

            // Calculamos el promedio
            estudiante.Promedio =
                (estudiante.Nota1 + estudiante.Nota2 +
                 estudiante.Nota3 + estudiante.Nota4) / 4;

            // Asignamos el literal según el promedio
            if (estudiante.Promedio >= 90)
            {
                estudiante.Literal = "A";
            }
            else if (estudiante.Promedio >= 80)
            {
                estudiante.Literal = "B";
            }
            else if (estudiante.Promedio >= 70)
            {
                estudiante.Literal = "C";
            }
            else
            {
                estudiante.Literal = "D";
            }

            // Agregamos el estudiante a la lista
            estudiantes.Add(estudiante);

            // Preguntamos si desea ingresar otro
            Console.Write("\n¿Desea ingresar otro estudiante? (S/N): ");
            continuar = Console.ReadLine();
        }

        // Mostramos el reporte
        Console.WriteLine("\n");
        Console.WriteLine("COLEGIO DIOS ES BUENO");
        Console.WriteLine("CALIFICACIONES DEL CUATRIMESTRE");
        Console.WriteLine("==============================================================");
        Console.WriteLine("Nombre\tApellido\tNota1\tNota2\tNota3\tNota4\tPromedio\tLiteral");
        Console.WriteLine("==============================================================");

        // Recorremos la lista y mostramos los estudiantes
        foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine(
                estudiante.Nombre + "\t" +
                estudiante.Apellido + "\t\t" +
                estudiante.Nota1 + "\t" +
                estudiante.Nota2 + "\t" +
                estudiante.Nota3 + "\t" +
                estudiante.Nota4 + "\t" +
                estudiante.Promedio.ToString("0.00") + "\t\t" +
                estudiante.Literal
            );
        }
    }
}