// Harol R. Paredes Perez
// Matricula colegial: 2026-0187

namespace CRUD_PERSONAS
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            IdLabel = new Label();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            lblNombre = new Label();
            txtCorreo = new TextBox();
            lblApellido = new Label();
            lblCorreo = new Label();
            dgvPersonas = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colCorreo = new DataGridViewTextBoxColumn();
            btnBuscar = new Button();
            btnGuardar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            SuspendLayout();
            IdLabel.AutoSize = true;
            IdLabel.Location = new Point(38, 25);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(24, 18);
            IdLabel.TabIndex = 0;
            IdLabel.Text = "ID";
            txtId.Location = new Point(38, 53);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 24);
            txtId.TabIndex = 1;
            txtNombre.Location = new Point(259, 53);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(233, 24);
            txtNombre.TabIndex = 2;
            txtApellido.Location = new Point(38, 120);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(150, 24);
            txtApellido.TabIndex = 3;
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(259, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(56, 18);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            lblNombre.Click += labelNombre_Click;
            txtCorreo.Location = new Point(259, 120);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(233, 24);
            txtCorreo.TabIndex = 5;
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(38, 90);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(72, 18);
            lblApellido.TabIndex = 6;
            lblApellido.Text = "Apellido";
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(259, 90);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(56, 18);
            lblCorreo.TabIndex = 7;
            lblCorreo.Text = "Correo";
            dgvPersonas.AllowUserToAddRows = false;
            dgvPersonas.AllowUserToDeleteRows = false;
            dgvPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonas.BackgroundColor = SystemColors.ActiveBorder;
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonas.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colApellido, colCorreo });
            dgvPersonas.Location = new Point(24, 228);
            dgvPersonas.MultiSelect = false;
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.ReadOnly = true;
            dgvPersonas.RowHeadersVisible = false;
            dgvPersonas.RowHeadersWidth = 51;
            dgvPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonas.Size = new Size(740, 165);
            dgvPersonas.TabIndex = 8;
            dgvPersonas.CellContentDoubleClick += dgvPersonas_CellDoubleClick;
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            colApellido.HeaderText = "Apellido";
            colApellido.MinimumWidth = 6;
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            colCorreo.HeaderText = "Correo";
            colCorreo.MinimumWidth = 6;
            colCorreo.Name = "colCorreo";
            colCorreo.ReadOnly = true;
            btnBuscar.Location = new Point(148, 170);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(104, 29);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            btnGuardar.Location = new Point(38, 170);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(104, 29);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            btnActualizar.Location = new Point(259, 170);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(104, 29);
            btnActualizar.TabIndex = 11;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click_1;
            btnEliminar.Location = new Point(369, 170);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(104, 29);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click_1;
            btnLimpiar.Location = new Point(479, 170);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(104, 29);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click_1;
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(800, 412);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnGuardar);
            Controls.Add(btnBuscar);
            Controls.Add(dgvPersonas);
            Controls.Add(lblCorreo);
            Controls.Add(lblApellido);
            Controls.Add(txtCorreo);
            Controls.Add(lblNombre);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Controls.Add(IdLabel);
            Font = new Font("Ubuntu Mono Medium", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "Directorio De Personas";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IdLabel;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label lblNombre;
        private TextBox txtCorreo;
        private Label lblApellido;
        private Label lblCorreo;
        private DataGridView dgvPersonas;
        private Button btnBuscar;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colCorreo;
    }
}
