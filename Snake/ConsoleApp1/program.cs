using System.Drawing;
using juegosnake;

internal static class Program
{
    private static readonly Random Aleatorio = new();

    private static void Main()
    {
        if (Console.IsInputRedirected || Console.IsOutputRedirected)
        {
            Console.WriteLine("Ejecuta el juego en una terminal interactiva (dotnet run).");
            return;
        }

        Ventana ventana = new("Snake", 65, 20, ConsoleColor.Black,
            ConsoleColor.Green, new Point(0, 0), new Point(64, 19));

        try
        {
            bool salir = false;
            while (!salir)
            {
                Snake serpiente = new(ventana);
                int puntos = 0;
                Point comida = GenerarComida(ventana, serpiente);
                bool terminado = false;

                Console.Write("\u001b[2J\u001b[H");
                ventana.Dibujar(serpiente, comida, puntos, terminado);
                long proximoPaso = Environment.TickCount64 + 130;

                while (!salir)
                {
                    while (Console.KeyAvailable)
                    {
                        ConsoleKey tecla = Console.ReadKey(intercept: true).Key;
                        if (tecla == ConsoleKey.Escape) { salir = true; break; }
                        if (terminado)
                        {
                            if (tecla == ConsoleKey.R) goto Reiniciar;
                        }
                        else serpiente.CambiarDireccion(tecla);
                    }
                    if (salir) break;
                    if (!terminado && Environment.TickCount64 >= proximoPaso)
                    {
                        if (serpiente.Mover(comida))
                        {
                            puntos += 10;
                            // La serpiente ganó si llenó el área interior entera.
                            if (serpiente.Cuerpo.Count ==
                                (ventana.Ancho - 2) * (ventana.Alto - 2))
                            {
                                terminado = true;
                            }
                            else comida = GenerarComida(ventana, serpiente);
                        }
                        if (!serpiente.Vivo) terminado = true;
                        ventana.Dibujar(serpiente, comida, puntos, terminado);
                        proximoPaso = Environment.TickCount64 + Math.Max(65, 130 - puntos / 20);
                    }
                    Thread.Sleep(10);
                }
                break;
            Reiniciar:;
            }
        }
        finally
        {
            Console.ResetColor();
            Console.CursorVisible = true;
            Console.Write("\u001b[0m\n");
        }
    }

    private static Point GenerarComida(Ventana ventana, Snake serpiente)
    {
        Point lugar;
        do
        {
            lugar = new Point(
                Aleatorio.Next(ventana.LimiteSuperior.X + 1, ventana.LimiteInferior.X),
                Aleatorio.Next(ventana.LimiteSuperior.Y + 1, ventana.LimiteInferior.Y));
        }
        while (serpiente.Cuerpo.Contains(lugar));
        return lugar;
    }
}
