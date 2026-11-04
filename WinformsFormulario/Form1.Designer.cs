// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

namespace VideoFormulario;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private Label lblNombre;
    private Label lblEdad;
    private TextBox txtNombre;
    private TextBox txtEdad;
    private Button btnGuardar;
    private Button btnLimpiar;
    private DataGridView grilla;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        lblNombre = new Label();
        lblNombre.Text = "Nombre";
        lblNombre.Location = new Point(20, 20);
        lblNombre.Size = new Size(75, 23);

        txtNombre = new TextBox();
        txtNombre.Location = new Point(100, 20);
        txtNombre.Size = new Size(200, 23);

        lblEdad = new Label();
        lblEdad.Text = "Edad";
        lblEdad.Location = new Point(20, 60);
        lblEdad.Size = new Size(60, 23);

        txtEdad = new TextBox();
        txtEdad.Location = new Point(100, 60);
        txtEdad.Size = new Size(200, 23);

        btnGuardar = new Button();
        btnGuardar.Text = "Guardar";
        btnGuardar.Location = new Point(20, 100);
        btnGuardar.Size = new Size(100, 30);
        btnGuardar.Click += btnGuardar_Click;

        btnLimpiar = new Button();
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.Location = new Point(140, 100);
        btnLimpiar.Size = new Size(100, 30);
        btnLimpiar.Click += btnLimpiar_Click;

        grilla = new DataGridView();
        grilla.ReadOnly = true;
        grilla.AllowUserToAddRows = false;
        grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grilla.Location = new Point(20, 150);
        grilla.Size = new Size(540, 250);

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(600, 430);
        Text = "Registro de usuarios";
        AcceptButton = btnGuardar;

        Controls.Add(lblNombre);
        Controls.Add(txtNombre);
        Controls.Add(lblEdad);
        Controls.Add(txtEdad);
        Controls.Add(btnGuardar);
        Controls.Add(btnLimpiar);
        Controls.Add(grilla);
    }
}
