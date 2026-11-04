// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

using System.Security.Cryptography;
using System.Text;

namespace CRUD_PERSONAS;

internal sealed class LoginForm : Form
{
    private readonly TextBox usuario = new() { Width = 240 };
    private readonly TextBox clave = new() { Width = 240, UseSystemPasswordChar = true };

    public LoginForm(string usuarioConfigurado, string claveConfigurada)
    {
        Text = "Inicio de sesión";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;

        var entrar = new Button { Text = "Entrar", AutoSize = true };
        var cancelar = new Button { Text = "Cancelar", AutoSize = true, DialogResult = DialogResult.Cancel };
        var botones = new FlowLayoutPanel { AutoSize = true };
        botones.Controls.AddRange(new Control[] { entrar, cancelar });

        var contenido = new FlowLayoutPanel
        {
            AutoSize = true,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(16)
        };
        contenido.Controls.AddRange(new Control[]
        {
            new Label { Text = "Usuario", AutoSize = true }, usuario,
            new Label { Text = "Contraseña", AutoSize = true }, clave, botones
        });
        Controls.Add(contenido);
        AcceptButton = entrar;
        CancelButton = cancelar;

        byte[] claveEsperada = SHA256.HashData(Encoding.UTF8.GetBytes(claveConfigurada));
        entrar.Click += (_, _) =>
        {
            byte[] claveIngresada = SHA256.HashData(Encoding.UTF8.GetBytes(clave.Text));
            if (string.Equals(usuario.Text.Trim(), usuarioConfigurado, StringComparison.OrdinalIgnoreCase)
                && CryptographicOperations.FixedTimeEquals(claveIngresada, claveEsperada))
            {
                DialogResult = DialogResult.OK;
                return;
            }

            MessageBox.Show(this, "Usuario o contraseña incorrectos.", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            clave.Clear();
            clave.Focus();
        };
    }
}
