namespace Hostal_App.Views
{
    partial class Clientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panDataCliente = new System.Windows.Forms.Panel();
            this.materialLabel27 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBuscarCliente = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.panCRUDCliente = new System.Windows.Forms.Panel();
            this.materialLabel50 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel49 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel48 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel47 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel46 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel45 = new MaterialSkin.Controls.MaterialLabel();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.lblIdCliente = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.btnActualizarCliente = new System.Windows.Forms.Button();
            this.txtDireccionCliente = new System.Windows.Forms.TextBox();
            this.txtApellidoCliente = new System.Windows.Forms.TextBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.panDataCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.panCRUDCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // panDataCliente
            // 
            this.panDataCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.panDataCliente.Controls.Add(this.materialLabel27);
            this.panDataCliente.Controls.Add(this.btnBuscarCliente);
            this.panDataCliente.Controls.Add(this.materialLabel1);
            this.panDataCliente.Controls.Add(this.dataGridViewClientes);
            this.panDataCliente.Controls.Add(this.txtBuscarCliente);
            this.panDataCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDataCliente.Location = new System.Drawing.Point(3, 64);
            this.panDataCliente.Name = "panDataCliente";
            this.panDataCliente.Size = new System.Drawing.Size(994, 245);
            this.panDataCliente.TabIndex = 29;
            // 
            // materialLabel27
            // 
            this.materialLabel27.AutoSize = true;
            this.materialLabel27.Depth = 0;
            this.materialLabel27.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel27.Location = new System.Drawing.Point(862, 55);
            this.materialLabel27.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel27.Name = "materialLabel27";
            this.materialLabel27.Size = new System.Drawing.Size(57, 19);
            this.materialLabel27.TabIndex = 10;
            this.materialLabel27.Text = "Clientes";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarCliente.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscarCliente.Depth = 0;
            this.btnBuscarCliente.HighEmphasis = true;
            this.btnBuscarCliente.Icon = null;
            this.btnBuscarCliente.Location = new System.Drawing.Point(299, 23);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscarCliente.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscarCliente.Size = new System.Drawing.Size(77, 36);
            this.btnBuscarCliente.TabIndex = 9;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscarCliente.UseAccentColor = false;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(16, 33);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(50, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Buscar";
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.AllowUserToAddRows = false;
            this.dataGridViewClientes.AllowUserToDeleteRows = false;
            this.dataGridViewClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Location = new System.Drawing.Point(19, 79);
            this.dataGridViewClientes.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.ReadOnly = true;
            this.dataGridViewClientes.Size = new System.Drawing.Size(900, 150);
            this.dataGridViewClientes.TabIndex = 0;
            this.dataGridViewClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientes_CellClick);
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(104, 30);
            this.txtBuscarCliente.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(164, 20);
            this.txtBuscarCliente.TabIndex = 6;
            // 
            // panCRUDCliente
            // 
            this.panCRUDCliente.BackColor = System.Drawing.Color.Gainsboro;
            this.panCRUDCliente.Controls.Add(this.materialLabel50);
            this.panCRUDCliente.Controls.Add(this.materialLabel49);
            this.panCRUDCliente.Controls.Add(this.materialLabel48);
            this.panCRUDCliente.Controls.Add(this.materialLabel47);
            this.panCRUDCliente.Controls.Add(this.materialLabel46);
            this.panCRUDCliente.Controls.Add(this.materialLabel45);
            this.panCRUDCliente.Controls.Add(this.btnEliminarCliente);
            this.panCRUDCliente.Controls.Add(this.lblIdCliente);
            this.panCRUDCliente.Controls.Add(this.txtIdentificacion);
            this.panCRUDCliente.Controls.Add(this.txtTelefonoCliente);
            this.panCRUDCliente.Controls.Add(this.btnActualizarCliente);
            this.panCRUDCliente.Controls.Add(this.txtDireccionCliente);
            this.panCRUDCliente.Controls.Add(this.txtApellidoCliente);
            this.panCRUDCliente.Controls.Add(this.btnAgregarCliente);
            this.panCRUDCliente.Controls.Add(this.txtNombreCliente);
            this.panCRUDCliente.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panCRUDCliente.Location = new System.Drawing.Point(3, 309);
            this.panCRUDCliente.Name = "panCRUDCliente";
            this.panCRUDCliente.Size = new System.Drawing.Size(994, 238);
            this.panCRUDCliente.TabIndex = 28;
            // 
            // materialLabel50
            // 
            this.materialLabel50.AutoSize = true;
            this.materialLabel50.Depth = 0;
            this.materialLabel50.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel50.Location = new System.Drawing.Point(529, 27);
            this.materialLabel50.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel50.Name = "materialLabel50";
            this.materialLabel50.Size = new System.Drawing.Size(67, 19);
            this.materialLabel50.TabIndex = 27;
            this.materialLabel50.Text = "Dirección";
            // 
            // materialLabel49
            // 
            this.materialLabel49.AutoSize = true;
            this.materialLabel49.Depth = 0;
            this.materialLabel49.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel49.Location = new System.Drawing.Point(532, 77);
            this.materialLabel49.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel49.Name = "materialLabel49";
            this.materialLabel49.Size = new System.Drawing.Size(64, 19);
            this.materialLabel49.TabIndex = 26;
            this.materialLabel49.Text = "Teléfono";
            // 
            // materialLabel48
            // 
            this.materialLabel48.AutoSize = true;
            this.materialLabel48.Depth = 0;
            this.materialLabel48.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel48.Location = new System.Drawing.Point(136, 16);
            this.materialLabel48.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel48.Name = "materialLabel48";
            this.materialLabel48.Size = new System.Drawing.Size(57, 19);
            this.materialLabel48.TabIndex = 25;
            this.materialLabel48.Text = "Nombre";
            // 
            // materialLabel47
            // 
            this.materialLabel47.AutoSize = true;
            this.materialLabel47.Depth = 0;
            this.materialLabel47.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel47.Location = new System.Drawing.Point(136, 71);
            this.materialLabel47.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel47.Name = "materialLabel47";
            this.materialLabel47.Size = new System.Drawing.Size(58, 19);
            this.materialLabel47.TabIndex = 24;
            this.materialLabel47.Text = "Apellido";
            // 
            // materialLabel46
            // 
            this.materialLabel46.AutoSize = true;
            this.materialLabel46.Depth = 0;
            this.materialLabel46.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel46.Location = new System.Drawing.Point(83, 121);
            this.materialLabel46.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel46.Name = "materialLabel46";
            this.materialLabel46.Size = new System.Drawing.Size(111, 19);
            this.materialLabel46.TabIndex = 23;
            this.materialLabel46.Text = "Identificacion #";
            // 
            // materialLabel45
            // 
            this.materialLabel45.AutoSize = true;
            this.materialLabel45.Depth = 0;
            this.materialLabel45.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel45.Location = new System.Drawing.Point(16, 13);
            this.materialLabel45.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel45.Name = "materialLabel45";
            this.materialLabel45.Size = new System.Drawing.Size(14, 19);
            this.materialLabel45.TabIndex = 22;
            this.materialLabel45.Text = "Id";
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminarCliente.Location = new System.Drawing.Point(476, 171);
            this.btnEliminarCliente.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(167, 39);
            this.btnEliminarCliente.TabIndex = 3;
            this.btnEliminarCliente.Text = "Eliminar";
            this.btnEliminarCliente.UseVisualStyleBackColor = false;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // lblIdCliente
            // 
            this.lblIdCliente.AutoSize = true;
            this.lblIdCliente.Location = new System.Drawing.Point(38, 16);
            this.lblIdCliente.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIdCliente.Name = "lblIdCliente";
            this.lblIdCliente.Size = new System.Drawing.Size(0, 13);
            this.lblIdCliente.TabIndex = 21;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(201, 120);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(284, 20);
            this.txtIdentificacion.TabIndex = 20;
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Location = new System.Drawing.Point(604, 74);
            this.txtTelefonoCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.Size = new System.Drawing.Size(284, 20);
            this.txtTelefonoCliente.TabIndex = 19;
            // 
            // btnActualizarCliente
            // 
            this.btnActualizarCliente.BackColor = System.Drawing.Color.RosyBrown;
            this.btnActualizarCliente.Location = new System.Drawing.Point(270, 171);
            this.btnActualizarCliente.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnActualizarCliente.Name = "btnActualizarCliente";
            this.btnActualizarCliente.Size = new System.Drawing.Size(167, 39);
            this.btnActualizarCliente.TabIndex = 2;
            this.btnActualizarCliente.Text = "Actualizar";
            this.btnActualizarCliente.UseVisualStyleBackColor = false;
            this.btnActualizarCliente.Click += new System.EventHandler(this.btnActualizarCliente_Click);
            // 
            // txtDireccionCliente
            // 
            this.txtDireccionCliente.Location = new System.Drawing.Point(604, 23);
            this.txtDireccionCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDireccionCliente.Name = "txtDireccionCliente";
            this.txtDireccionCliente.Size = new System.Drawing.Size(284, 20);
            this.txtDireccionCliente.TabIndex = 18;
            // 
            // txtApellidoCliente
            // 
            this.txtApellidoCliente.Location = new System.Drawing.Point(201, 68);
            this.txtApellidoCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtApellidoCliente.Name = "txtApellidoCliente";
            this.txtApellidoCliente.Size = new System.Drawing.Size(284, 20);
            this.txtApellidoCliente.TabIndex = 17;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.BackColor = System.Drawing.Color.RosyBrown;
            this.btnAgregarCliente.Location = new System.Drawing.Point(53, 171);
            this.btnAgregarCliente.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(167, 39);
            this.btnAgregarCliente.TabIndex = 1;
            this.btnAgregarCliente.Text = "Agregar";
            this.btnAgregarCliente.UseVisualStyleBackColor = false;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(201, 13);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(284, 20);
            this.txtNombreCliente.TabIndex = 16;
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panDataCliente);
            this.Controls.Add(this.panCRUDCliente);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Clientes";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.panDataCliente.ResumeLayout(false);
            this.panDataCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.panCRUDCliente.ResumeLayout(false);
            this.panCRUDCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panDataCliente;
        private MaterialSkin.Controls.MaterialLabel materialLabel27;
        private MaterialSkin.Controls.MaterialButton btnBuscarCliente;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Panel panCRUDCliente;
        private MaterialSkin.Controls.MaterialLabel materialLabel50;
        private MaterialSkin.Controls.MaterialLabel materialLabel49;
        private MaterialSkin.Controls.MaterialLabel materialLabel48;
        private MaterialSkin.Controls.MaterialLabel materialLabel47;
        private MaterialSkin.Controls.MaterialLabel materialLabel46;
        private MaterialSkin.Controls.MaterialLabel materialLabel45;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.Label lblIdCliente;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.Button btnActualizarCliente;
        private System.Windows.Forms.TextBox txtDireccionCliente;
        private System.Windows.Forms.TextBox txtApellidoCliente;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
    }
}