// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

namespace VideoFormulario;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
