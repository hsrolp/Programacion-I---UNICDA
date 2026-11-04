// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

class program
{
    const string ArchivoEstudiantes = "estudiantes.txt";
    static List<Curso> Cursos = new List<Curso>();

    static void Main(string[] args)
    {
        try
        {
            CargarEstudiantes();
        }
        catch (Exception error) when (error is IOException || error is InvalidDataException || error is UnauthorizedAccessException)
        {
            Console.WriteLine("No se pudo leer estudiantes.txt: " + error.Message);
            return;
        }

        bool showMenu = true;

        while (showMenu)
        {
            try
            {
                showMenu = MainMenu();
            }
            catch (EndOfStreamException)
            {
                return;
            }
            catch (Exception error) when (error is IOException || error is UnauthorizedAccessException)
            {
                Console.WriteLine("Error de archivo: " + error.Message);
                Pausa();
            }
        }
    }

    static bool MainMenu()
    {
        if (!Console.IsOutputRedirected) Console.Clear();

        Console.WriteLine("==========================================================================");
        Console.WriteLine("COLEGIO DIOS ES BUENO");
        Console.WriteLine("==========================================================================");
        Console.WriteLine("1) Agregar estudiante");
        Console.WriteLine("2) Eliminar estudiante");
        Console.WriteLine("3) Reporte de notas");
        Console.WriteLine("4) Salir");
        Console.Write("\nSeleccione una opción: ");

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                AgregarEstudiante();
                return true;

            case "2":
                EliminarEstudiante();
                return true;

            case "3":
                ReporteNotas();
                return true;

            case null:
                return false;

            case "4":
                Salir();
                return false;

            default:
                return true;
        }
    }

    static void AgregarEstudiante()
    {
        if (!Console.IsOutputRedirected) Console.Clear();

        Console.WriteLine("======== CURSOS ========");

        if (Cursos.Count > 0)
        {
            for (int i = 0; i < Cursos.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Cursos[i].Nombre}");
            }
        }

        Console.WriteLine($"{Cursos.Count + 1}) Crear nuevo curso");

        Console.Write("\nSeleccione un curso: ");
        int opcionCurso = LeerOpcion(Cursos.Count + 1);

        Curso curso;

        if (opcionCurso == Cursos.Count + 1)
        {
            Console.Write("Ingrese el nombre del nuevo curso: ");
            string nombreCurso = LeerTexto();

            curso = BuscarCurso(nombreCurso) ?? new Curso(nombreCurso);
        }
        else
        {
            curso = Cursos[opcionCurso - 1];
        }

        Console.WriteLine();
        Console.WriteLine("======== AGREGAR ESTUDIANTE =========");

        Console.Write("Nombre: ");
        string nombre = LeerTexto();

        Console.Write("Apellido: ");
        string apellido = LeerTexto();

        Console.Write("Nota 1: ");
        double nota1 = LeerNota();

        Console.Write("Nota 2: ");
        double nota2 = LeerNota();

        Console.Write("Nota 3: ");
        double nota3 = LeerNota();

        Console.Write("Nota 4: ");
        double nota4 = LeerNota();

        Estudiante estudiante = CrearEstudiante(nombre, apellido, nota1, nota2, nota3, nota4);
        var registros = Registros().Concat(new[] { FormatearRegistro(curso, estudiante) });
        GuardarEstudiantes(registros);
        if (!Cursos.Contains(curso)) Cursos.Add(curso);
        curso.AgregarEstudiante(estudiante);

        Console.WriteLine();
        Console.WriteLine("Estudiante agregado.");
        Console.WriteLine("Curso: " + curso.Nombre);
        Console.WriteLine("Promedio: " + estudiante.Promedio.ToString("F2"));

        Pausa();
    }

    static void EliminarEstudiante()
    {
        if (!Console.IsOutputRedirected) Console.Clear();

        if (Cursos.Count == 0)
        {
            Console.WriteLine("No hay cursos registrados.");
            Pausa();
            return;
        }

        Console.WriteLine("======== CURSOS ========");

        for (int i = 0; i < Cursos.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {Cursos[i].Nombre}");
        }

        Console.Write("\nSeleccione el curso: ");
        int opcionCurso = LeerOpcion(Cursos.Count);

        Curso curso = Cursos[opcionCurso - 1];

        Console.WriteLine();
        if (curso.Estudiantes.Count == 0)
        {
            Console.WriteLine("Este curso no tiene estudiantes.");
            Pausa();
            return;
        }

        Console.WriteLine("Estudiantes del curso:");

        for (int i = 0; i < curso.Estudiantes.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}) {curso.Estudiantes[i].Nombre} {curso.Estudiantes[i].Apellido}");
        }

        Console.Write("\nSeleccione el estudiante que desea eliminar: ");
        int opcionEstudiante = LeerOpcion(curso.Estudiantes.Count);

        Estudiante estudiante = curso.Estudiantes[opcionEstudiante - 1];

        GuardarEstudiantes(Registros(estudiante));
        curso.Estudiantes.Remove(estudiante);

        Console.WriteLine();
        Console.WriteLine("Estudiante eliminado.");

        Pausa();

    }

    static void ReporteNotas()
    {
        if (!Console.IsOutputRedirected) Console.Clear();

        if (!Cursos.Any(c => c.Estudiantes.Count > 0))
        {
            Console.WriteLine("No hay estudiantes, agregue a alguien primero.");
            Pausa();
            return;
        }

        string reporte = "";

        Console.WriteLine("COLEGIO DIOS ES BUENO");
        Console.WriteLine("CALIFICACIONES DEL CUATRIMESTRE");
        Console.WriteLine();

        reporte += "COLEGIO DIOS ES BUENO\n";
        reporte += "CALIFICACIONES DEL CUATRIMESTRE\n\n";

        foreach (Curso curso in Cursos.OrderBy(c => c.Nombre))
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("CURSO: " + curso.Nombre);
            Console.WriteLine("==============================================");

            reporte += "==============================================\n";
            reporte += "CURSO: " + curso.Nombre + "\n";
            reporte += "==============================================\n";

            Console.WriteLine(
                "Nombre       Apellido       Nota1  Nota2  Nota3  Nota4  Promedio  Literal");

            Console.WriteLine(
                "==========================================================================");

            reporte +=
                "Nombre       Apellido       Nota1  Nota2  Nota3  Nota4  Promedio  Literal\n";

            reporte +=
                "==========================================================================\n";

            foreach (Estudiante estudiante in curso.Estudiantes.OrderBy(e => e.Apellido))
            {
                string linea =
                    $"{estudiante.Nombre,-12}" +
                    $"{estudiante.Apellido,-15}" +
                    $"{estudiante.Nota1,-7}" +
                    $"{estudiante.Nota2,-7}" +
                    $"{estudiante.Nota3,-7}" +
                    $"{estudiante.Nota4,-7}" +
                    $"{estudiante.Promedio,-10:F2}" +
                    $"{estudiante.Literal}";

                Console.WriteLine(linea);

                reporte += linea + "\n";
            }

            int cantidadA = curso.Estudiantes.Count(e => e.Literal == "A");
            int cantidadB = curso.Estudiantes.Count(e => e.Literal == "B");
            int cantidadC = curso.Estudiantes.Count(e => e.Literal == "C");
            int cantidadD = curso.Estudiantes.Count(e => e.Literal == "D");

            Console.WriteLine();
            Console.WriteLine("TOTALES");
            Console.WriteLine("=================================");
            Console.WriteLine("Estudiantes en A: " + cantidadA);
            Console.WriteLine("Estudiantes en B: " + cantidadB);
            Console.WriteLine("Estudiantes en C: " + cantidadC);
            Console.WriteLine("Estudiantes reprobados: " + cantidadD);
            Console.WriteLine();

            reporte += "\nTOTALES\n";
            reporte += "Estudiantes en A: " + cantidadA + "\n";
            reporte += "Estudiantes en B: " + cantidadB + "\n";
            reporte += "Estudiantes en C: " + cantidadC + "\n";
            reporte += "Estudiantes reprobados: " + cantidadD + "\n\n";
        }

        File.WriteAllText("reporte.txt", reporte);



        Pausa();
    }

    static void Pausa()
    {
        if (!Console.IsInputRedirected) Console.ReadLine();
    }

    static string LeerEntrada()
    {
        string entrada = Console.ReadLine();
        if (entrada == null) throw new EndOfStreamException();
        return entrada.Trim();
    }

    static string LeerTexto()
    {
        while (true)
        {
            string entrada = LeerEntrada();
            if (entrada.Length > 0) return entrada;
            Console.Write("Escriba un valor: ");
        }
    }

    static int LeerOpcion(int maximo)
    {
        while (true)
        {
            if (int.TryParse(LeerEntrada(), out int opcion) && opcion >= 1 && opcion <= maximo)
                return opcion;

            Console.Write($"Ingrese un número del 1 al {maximo}: ");
        }
    }

    static double LeerNota()
    {
        while (true)
        {
            if (LeerNumero(LeerEntrada(), out double nota) && nota >= 0 && nota <= 100)
                return nota;

            Console.Write("Ingrese una nota entre 0 y 100: ");
        }
    }

    static bool LeerNumero(string texto, out double nota)
    {
        return double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out nota)
            || double.TryParse(texto, NumberStyles.Float, CultureInfo.CurrentCulture, out nota)
            || double.TryParse(texto.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out nota);
    }

    static Curso BuscarCurso(string nombre)
    {
        return Cursos.Find(c => string.Equals(c.Nombre, nombre, StringComparison.OrdinalIgnoreCase));
    }

    static Estudiante CrearEstudiante(string nombre, string apellido, double nota1,
        double nota2, double nota3, double nota4)
    {
        double promedio = (nota1 + nota2 + nota3 + nota4) / 4;
        string literal = "D";
        if (promedio >= 90) literal = "A";
        else if (promedio >= 80) literal = "B";
        else if (promedio >= 70) literal = "C";

        return new Estudiante
        {
            Nombre = nombre,
            Apellido = apellido,
            Nota1 = nota1,
            Nota2 = nota2,
            Nota3 = nota3,
            Nota4 = nota4,
            Promedio = promedio,
            Literal = literal
        };
    }

    static void CargarEstudiantes()
    {
        string[] lineas;
        try
        {
            lineas = File.ReadAllLines(ArchivoEstudiantes);
        }
        catch (FileNotFoundException)
        {
            return;
        }

        string[] campos = { "Curso: ", "Nombre: ", "Apellido: ", "Nota 1: ",
            "Nota 2: ", "Nota 3: ", "Nota 4: ", "Promedio: ", "Literal: " };

        for (int i = 0; i < lineas.Length; i += 10)
        {
            if (i + 9 >= lineas.Length || lineas[i + 9] != "====================================")
                throw new InvalidDataException($"Registro incompleto en la línea {i + 1}.");

            var valores = new string[campos.Length];
            for (int j = 0; j < campos.Length; j++)
            {
                if (!lineas[i + j].StartsWith(campos[j], StringComparison.Ordinal))
                    throw new InvalidDataException($"Campo inválido en la línea {i + j + 1}.");

                valores[j] = lineas[i + j].Substring(campos[j].Length);
            }

            if (!LeerNumero(valores[3], out double nota1) || !LeerNumero(valores[4], out double nota2)
                || !LeerNumero(valores[5], out double nota3) || !LeerNumero(valores[6], out double nota4))
                throw new InvalidDataException($"Notas inválidas en el registro de la línea {i + 1}.");

            Curso curso = BuscarCurso(valores[0]);
            if (curso == null)
            {
                curso = new Curso(valores[0]);
                Cursos.Add(curso);
            }

            curso.AgregarEstudiante(CrearEstudiante(valores[1], valores[2], nota1, nota2, nota3, nota4));
        }
    }

    static IEnumerable<string> Registros(Estudiante omitido = null)
    {
        foreach (Curso curso in Cursos)
            foreach (Estudiante estudiante in curso.Estudiantes)
                if (estudiante != omitido)
                    yield return FormatearRegistro(curso, estudiante);
    }

    static string FormatearRegistro(Curso curso, Estudiante estudiante)
    {
        return FormattableString.Invariant(
            $"Curso: {curso.Nombre}\nNombre: {estudiante.Nombre}\nApellido: {estudiante.Apellido}\nNota 1: {estudiante.Nota1:R}\nNota 2: {estudiante.Nota2:R}\nNota 3: {estudiante.Nota3:R}\nNota 4: {estudiante.Nota4:R}\nPromedio: {estudiante.Promedio:F2}\nLiteral: {estudiante.Literal}\n====================================");
    }

    static void GuardarEstudiantes(IEnumerable<string> registros)
    {
        string temporal = ArchivoEstudiantes + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            File.WriteAllLines(temporal, registros);
            if (File.Exists(ArchivoEstudiantes))
                File.Replace(temporal, ArchivoEstudiantes, null);
            else
                File.Move(temporal, ArchivoEstudiantes);
        }
        finally
        {
            if (File.Exists(temporal)) File.Delete(temporal);
        }
    }

    static void Salir()
    {
        if (!Console.IsOutputRedirected) Console.Clear();

        Console.WriteLine("Presiona enter para salir.");

        Pausa();
    }
}


class Curso
{
    public string Nombre { get; set; }

    public List<Estudiante> Estudiantes { get; set; }

    public Curso(string nombre)
    {
        Nombre = nombre;
        Estudiantes = new List<Estudiante>();
    }

    public void AgregarEstudiante(Estudiante estudiante)
    {
        Estudiantes.Add(estudiante);
    }
}


class Estudiante
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    public double Nota1 { get; set; }
    public double Nota2 { get; set; }
    public double Nota3 { get; set; }
    public double Nota4 { get; set; }

    public double Promedio { get; set; }

    public string Literal { get; set; }
}
