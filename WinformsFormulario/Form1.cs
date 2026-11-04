// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

using System;
using System.Data;
using System.Windows.Forms;
using VideoFormulario.Datos;
using VideoFormulario.Modelo;

namespace VideoFormulario
{
    public partial class Form1 : Form
    {

        DataTable tabla;
        Usuario dato = new Usuario();

        public Form1()
        {
            InitializeComponent();
            Iniciar();
        }


        private void Iniciar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Edad");
            grilla.DataSource = tabla;
        }


        private void Guardar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Escribe un nombre.");
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad) || edad < 0 || edad > 120)
            {
                MessageBox.Show("Escribe una edad entera entre 0 y 120.");
                return;
            }

            UsuarioModel modelo = new UsuarioModel
            {
                Nombre = txtNombre.Text.Trim(),
                Edad = edad
            };

            dato.Guardar(modelo);

            Iniciar();
            Limpiar();
            Consultar();
        }

        private void Consultar()
        {
            foreach (var item in dato.Consultar())
            {
                tabla.Rows.Add(item.Nombre, item.Edad);
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtNombre.Focus();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            dato.Limpiar();
            Iniciar();
        }
    }
}
