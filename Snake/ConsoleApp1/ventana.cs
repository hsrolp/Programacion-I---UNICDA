using System.Drawing;
using System.Text;

namespace juegosnake;

internal class Ventana
{
    public string Titulo { get; set; }
    public int Ancho { get; set; }
    public int Alto { get; set; }
    public ConsoleColor ColorFondo { get; set; }
    public ConsoleColor ColorTexto { get; set; }
    public Point LimiteSuperior { get; set; }
    public Point LimiteInferior { get; set; }

    public Ventana(string titulo, int ancho, int alto, ConsoleColor colorFondo,
        ConsoleColor colorTexto, Point limiteSuperior, Point limiteInferior)
    {
        Titulo = titulo;
        Ancho = ancho;
        Alto = alto;
        ColorFondo = colorFondo;
        ColorTexto = colorTexto;
        LimiteSuperior = limiteSuperior;
        LimiteInferior = limiteInferior;
        Init();
    }

    public void Init()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = Titulo;
        Console.CursorVisible = false;
        Console.BackgroundColor = ColorFondo;
        Console.Clear();
        if (OperatingSystem.IsWindows())
        {
            try { Console.SetWindowSize(Ancho, Alto + 2); }
            catch (ArgumentOutOfRangeException) { /* La terminal decide el tamaño. */ }
            catch (IOException) { /* Algunas consolas no permiten redimensionar. */ }
        }
        else
        {
            
            Console.Write($"\u001b[8;{Alto + 2};{Ancho}t");
        }
    }

    
    public void DibujarMarco(char[,] tablero)
    {
        for (int x = LimiteSuperior.X; x <= LimiteInferior.X; x++)
        {
            tablero[LimiteSuperior.Y, x] = '═';
            tablero[LimiteInferior.Y, x] = '═';
        }
        for (int y = LimiteSuperior.Y; y <= LimiteInferior.Y; y++)
        {
            tablero[y, LimiteSuperior.X] = '║';
            tablero[y, LimiteInferior.X] = '║';
        }
        tablero[LimiteSuperior.Y, LimiteSuperior.X] = '╔';
        tablero[LimiteSuperior.Y, LimiteInferior.X] = '╗';
        tablero[LimiteInferior.Y, LimiteSuperior.X] = '╚';
        tablero[LimiteInferior.Y, LimiteInferior.X] = '╝';
    }

    public void Dibujar(Snake serpiente, Point comida, int puntos, bool terminado)
    {
        char[,] tablero = new char[Alto, Ancho];
        for (int y = 0; y < Alto; y++)
            for (int x = 0; x < Ancho; x++)
                tablero[y, x] = ' ';

        DibujarMarco(tablero);
        tablero[comida.Y, comida.X] = '●';
        foreach (Point segmento in serpiente.Cuerpo)
            tablero[segmento.Y, segmento.X] = '■';
        tablero[serpiente.Cabeza.Y, serpiente.Cabeza.X] = '■';

        StringBuilder pantalla = new("\u001b[H");
        for (int y = 0; y < Alto; y++)
        {
            string colorAnterior = "";
            for (int x = 0; x < Ancho; x++)
            {
                char simbolo = tablero[y, x];
                string color = simbolo switch
                {
                    '●' => "\u001b[91m", // Comida roja
                    '■' when x == serpiente.Cabeza.X && y == serpiente.Cabeza.Y => "\u001b[92m",
                    '■' => "\u001b[32m", // Cuerpo verde
                    '═' or '║' or '╔' or '╗' or '╚' or '╝' => "\u001b[36m",
                    _ => "\u001b[0m"
                };
                if (color != colorAnterior)
                {
                    pantalla.Append(color);
                    colorAnterior = color;
                }
                pantalla.Append(simbolo);
            }
            pantalla.Append("\u001b[0m\n");
        }
        pantalla.Append($"Puntos: {puntos}  |  Flechas/WASD: mover  |  Esc: salir");
        pantalla.Append("\u001b[K");
        if (terminado)
        {
            pantalla.Append("\n\u001b[93mPalomo\u001b[0m — R: reiniciar | Esc: salir\u001b[K");
        }
        else
        {
            pantalla.Append("\n\u001b[K");
        }
        Console.Write(pantalla.ToString());
    }
}
