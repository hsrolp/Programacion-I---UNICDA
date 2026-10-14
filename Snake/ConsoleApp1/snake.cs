using System.Drawing;

namespace juegosnake;

internal class Snake
{
    public bool Vivo { get; private set; } = true;
    public ConsoleColor ColorCabeza { get; set; } = ConsoleColor.Green;
    public ConsoleColor ColorCuerpo { get; set; } = ConsoleColor.DarkGreen;
    public Ventana VentanaC { get; }
    public List<Point> Cuerpo { get; } = new();
    public Point Cabeza => Cuerpo[0];

    private Point direccion = new(1, 0);
    private bool direccionCambiada;

    public Snake(Ventana ventana)
    {
        VentanaC = ventana;
        int x = (ventana.LimiteSuperior.X + ventana.LimiteInferior.X) / 2;
        int y = (ventana.LimiteSuperior.Y + ventana.LimiteInferior.Y) / 2;
        Cuerpo.Add(new Point(x, y));
        Cuerpo.Add(new Point(x - 1, y));
        Cuerpo.Add(new Point(x - 2, y));
    }

    // Solo permite un giro por paso, evitando retroceder sobre el propio cuerpo.
    public void CambiarDireccion(ConsoleKey tecla)
    {
        if (direccionCambiada) return;
        Point nueva = tecla switch
        {
            ConsoleKey.UpArrow or ConsoleKey.W => new Point(0, -1),
            ConsoleKey.DownArrow or ConsoleKey.S => new Point(0, 1),
            ConsoleKey.LeftArrow or ConsoleKey.A => new Point(-1, 0),
            ConsoleKey.RightArrow or ConsoleKey.D => new Point(1, 0),
            _ => direccion
        };
        if (nueva.X == -direccion.X && nueva.Y == -direccion.Y) return;
        direccionCambiada = true;
        direccion = nueva;
    }


    public bool Mover(Point comida)
    {
        if (!Vivo) return false;

        Point nuevaCabeza = new(Cabeza.X + direccion.X, Cabeza.Y + direccion.Y);
        bool come = nuevaCabeza == comida;
        bool chocaPared = nuevaCabeza.X <= VentanaC.LimiteSuperior.X ||
                          nuevaCabeza.X >= VentanaC.LimiteInferior.X ||
                          nuevaCabeza.Y <= VentanaC.LimiteSuperior.Y ||
                          nuevaCabeza.Y >= VentanaC.LimiteInferior.Y;


        int segmentosQueBloquean = Cuerpo.Count - (come ? 0 : 1);
        bool chocaCuerpo = Cuerpo.Take(segmentosQueBloquean).Contains(nuevaCabeza);
        if (chocaPared || chocaCuerpo)
        {
            Vivo = false;
            return false;
        }

        Cuerpo.Insert(0, nuevaCabeza);
        if (!come) Cuerpo.RemoveAt(Cuerpo.Count - 1);
        direccionCambiada = false;
        return come;
    }
}
