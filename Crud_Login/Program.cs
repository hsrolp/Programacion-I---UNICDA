// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

namespace CRUD_PERSONAS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            string usuario = Environment.GetEnvironmentVariable("CRUD_LOGIN_USUARIO");
            string clave = Environment.GetEnvironmentVariable("CRUD_LOGIN_CLAVE");
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Configura CRUD_LOGIN_USUARIO y CRUD_LOGIN_CLAVE para iniciar.",
                    "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var login = new LoginForm(usuario.Trim(), clave))
            {
                if (login.ShowDialog() != DialogResult.OK) return;
            }

            Application.Run(new Form1());
        }
    }
}
