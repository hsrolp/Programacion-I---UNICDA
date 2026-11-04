// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

using CRUD_PERSONAS.Models;
using CRUD_PERSONAS.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRUD_PERSONAS
{
    public partial class Form1 : Form
    {
        Datos datos = new Datos();
        Persona persona = new Persona();
        int id = 0;

        public Form1()
        {
            InitializeComponent();

            dgvPersonas.AutoGenerateColumns = false;
            colId.DataPropertyName = "Id";
            colNombre.DataPropertyName = "Nombre";
            colApellido.DataPropertyName = "Apellido";
            colCorreo.DataPropertyName = "Correo";

            txtId.ReadOnly = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            var ls = datos.Read();
            dgvPersonas.DataSource = ls;
        }

        private void CargarDatos()
        {
            persona.Id = id;
            persona.Nombre = txtNombre.Text.Trim();
            persona.Apellido = txtApellido.Text.Trim();
            persona.Correo = txtCorreo.Text.Trim();
        }

        private void Limpiar()
        {
            id = 0;
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtNombre.Focus();
            CargarGrid();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos antes de guardar.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarDatos();
            persona.Id = 0;
            if (!datos.Create(persona)) return;
            MessageBox.Show("Registro guardado");
            Limpiar();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (id > 0 && int.TryParse(txtId.Text, out int idVisible) && idVisible == id)
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("Los campos no pueden quedar vacíos.");
                    return;
                }

                CargarDatos();
                if (!datos.Update(persona)) return;
                MessageBox.Show("Registro actualizado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro haciendo doble clic en la tabla o buscarlo por ID.");
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (id > 0 && int.TryParse(txtId.Text, out int idVisible) && idVisible == id)
            {
                var respuesta = MessageBox.Show("¿Eliminar este registro?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta != DialogResult.Yes || !datos.Delete(id)) return;
                MessageBox.Show("Registro eliminado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro haciendo doble clic en la tabla o buscarlo por ID.");
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            id = 0;
            if (!int.TryParse(txtId.Text, out int idBuscar) || idBuscar <= 0)
            {
                MessageBox.Show("Ingrese un ID entero mayor que cero.");
                return;
            }

            var lista = datos.Read();
            var personaEncontrada = lista.FirstOrDefault(p => p.Id == idBuscar);

            if (personaEncontrada != null)
            {
                id = personaEncontrada.Id;

                txtNombre.Text = personaEncontrada.Nombre;
                txtApellido.Text = personaEncontrada.Apellido;
                txtCorreo.Text = personaEncontrada.Correo;
            }
            else
            {
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                MessageBox.Show("No se encontró ninguna persona con ese ID.");
            }
        }

        private void dgvPersonas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dgvPersonas.Rows[e.RowIndex].Cells["colId"].Value);
                txtId.Text = id.ToString();
                txtNombre.Text = dgvPersonas.Rows[e.RowIndex].Cells["colNombre"].Value.ToString();
                txtApellido.Text = dgvPersonas.Rows[e.RowIndex].Cells["colApellido"].Value.ToString();
                txtCorreo.Text = dgvPersonas.Rows[e.RowIndex].Cells["colCorreo"].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void labelNombre_Click(object sender, EventArgs e) { }
    }
}
