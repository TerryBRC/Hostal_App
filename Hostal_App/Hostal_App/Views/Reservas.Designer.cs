namespace Hostal_App.Views
{
    partial class Reservas
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
            this.panel11 = new System.Windows.Forms.Panel();
            this.materialLabel28 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBuscarReserva = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewReservas = new System.Windows.Forms.DataGridView();
            this.txtBuscarReserva = new System.Windows.Forms.TextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnEliminarReserva = new MaterialSkin.Controls.MaterialButton();
            this.btnActualizarReserva = new MaterialSkin.Controls.MaterialButton();
            this.btnAgregarReserva = new MaterialSkin.Controls.MaterialButton();
            this.btnLimpiar = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.materialLabel44 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel43 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel42 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel41 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel40 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel39 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.dtpEntrada = new System.Windows.Forms.DateTimePicker();
            this.cmbHabitaciones = new System.Windows.Forms.ComboBox();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.lblIdReserva = new System.Windows.Forms.Label();
            this.txtNumeroHuespedes = new System.Windows.Forms.TextBox();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).BeginInit();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gainsboro;
            this.panel11.Controls.Add(this.materialLabel28);
            this.panel11.Controls.Add(this.btnBuscarReserva);
            this.panel11.Controls.Add(this.materialLabel2);
            this.panel11.Controls.Add(this.dataGridViewReservas);
            this.panel11.Controls.Add(this.txtBuscarReserva);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 64);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(994, 236);
            this.panel11.TabIndex = 31;
            // 
            // materialLabel28
            // 
            this.materialLabel28.AutoSize = true;
            this.materialLabel28.Depth = 0;
            this.materialLabel28.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel28.Location = new System.Drawing.Point(854, 56);
            this.materialLabel28.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel28.Name = "materialLabel28";
            this.materialLabel28.Size = new System.Drawing.Size(65, 19);
            this.materialLabel28.TabIndex = 11;
            this.materialLabel28.Text = "Reservas";
            // 
            // btnBuscarReserva
            // 
            this.btnBuscarReserva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarReserva.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscarReserva.Depth = 0;
            this.btnBuscarReserva.HighEmphasis = true;
            this.btnBuscarReserva.Icon = null;
            this.btnBuscarReserva.Location = new System.Drawing.Point(299, 23);
            this.btnBuscarReserva.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscarReserva.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscarReserva.Name = "btnBuscarReserva";
            this.btnBuscarReserva.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscarReserva.Size = new System.Drawing.Size(77, 36);
            this.btnBuscarReserva.TabIndex = 10;
            this.btnBuscarReserva.Text = "Buscar";
            this.btnBuscarReserva.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscarReserva.UseAccentColor = false;
            this.btnBuscarReserva.UseVisualStyleBackColor = true;
            this.btnBuscarReserva.Click += new System.EventHandler(this.btnBuscarReserva_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(16, 33);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(50, 19);
            this.materialLabel2.TabIndex = 9;
            this.materialLabel2.Text = "Buscar";
            // 
            // dataGridViewReservas
            // 
            this.dataGridViewReservas.AllowUserToAddRows = false;
            this.dataGridViewReservas.AllowUserToDeleteRows = false;
            this.dataGridViewReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservas.Location = new System.Drawing.Point(19, 79);
            this.dataGridViewReservas.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewReservas.Name = "dataGridViewReservas";
            this.dataGridViewReservas.ReadOnly = true;
            this.dataGridViewReservas.Size = new System.Drawing.Size(900, 150);
            this.dataGridViewReservas.TabIndex = 0;
            this.dataGridViewReservas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReservas_CellClick);
            this.dataGridViewReservas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewReservas_CellFormatting);
            // 
            // txtBuscarReserva
            // 
            this.txtBuscarReserva.Location = new System.Drawing.Point(104, 30);
            this.txtBuscarReserva.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBuscarReserva.Name = "txtBuscarReserva";
            this.txtBuscarReserva.Size = new System.Drawing.Size(164, 20);
            this.txtBuscarReserva.TabIndex = 6;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Gainsboro;
            this.panel12.Controls.Add(this.btnEliminarReserva);
            this.panel12.Controls.Add(this.btnActualizarReserva);
            this.panel12.Controls.Add(this.btnAgregarReserva);
            this.panel12.Controls.Add(this.btnLimpiar);
            this.panel12.Controls.Add(this.materialLabel5);
            this.panel12.Controls.Add(this.cmbEstado);
            this.panel12.Controls.Add(this.materialLabel44);
            this.panel12.Controls.Add(this.materialLabel43);
            this.panel12.Controls.Add(this.materialLabel42);
            this.panel12.Controls.Add(this.materialLabel41);
            this.panel12.Controls.Add(this.materialLabel40);
            this.panel12.Controls.Add(this.materialLabel39);
            this.panel12.Controls.Add(this.dtpSalida);
            this.panel12.Controls.Add(this.dtpEntrada);
            this.panel12.Controls.Add(this.cmbHabitaciones);
            this.panel12.Controls.Add(this.cmbClientes);
            this.panel12.Controls.Add(this.lblIdReserva);
            this.panel12.Controls.Add(this.txtNumeroHuespedes);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(3, 300);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(994, 247);
            this.panel12.TabIndex = 30;
            // 
            // btnEliminarReserva
            // 
            this.btnEliminarReserva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminarReserva.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEliminarReserva.Depth = 0;
            this.btnEliminarReserva.HighEmphasis = true;
            this.btnEliminarReserva.Icon = null;
            this.btnEliminarReserva.Location = new System.Drawing.Point(385, 163);
            this.btnEliminarReserva.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEliminarReserva.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEliminarReserva.Name = "btnEliminarReserva";
            this.btnEliminarReserva.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEliminarReserva.Size = new System.Drawing.Size(88, 36);
            this.btnEliminarReserva.TabIndex = 37;
            this.btnEliminarReserva.Text = "Eliminar";
            this.btnEliminarReserva.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEliminarReserva.UseAccentColor = false;
            this.btnEliminarReserva.UseVisualStyleBackColor = true;
            this.btnEliminarReserva.Click += new System.EventHandler(this.btnEliminarReserva_Click);
            // 
            // btnActualizarReserva
            // 
            this.btnActualizarReserva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarReserva.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnActualizarReserva.Depth = 0;
            this.btnActualizarReserva.HighEmphasis = true;
            this.btnActualizarReserva.Icon = null;
            this.btnActualizarReserva.Location = new System.Drawing.Point(247, 163);
            this.btnActualizarReserva.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnActualizarReserva.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActualizarReserva.Name = "btnActualizarReserva";
            this.btnActualizarReserva.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnActualizarReserva.Size = new System.Drawing.Size(109, 36);
            this.btnActualizarReserva.TabIndex = 36;
            this.btnActualizarReserva.Text = "Actualizar";
            this.btnActualizarReserva.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnActualizarReserva.UseAccentColor = false;
            this.btnActualizarReserva.UseVisualStyleBackColor = true;
            this.btnActualizarReserva.Click += new System.EventHandler(this.btnActualizarReserva_Click);
            // 
            // btnAgregarReserva
            // 
            this.btnAgregarReserva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarReserva.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregarReserva.Depth = 0;
            this.btnAgregarReserva.HighEmphasis = true;
            this.btnAgregarReserva.Icon = null;
            this.btnAgregarReserva.Location = new System.Drawing.Point(132, 163);
            this.btnAgregarReserva.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregarReserva.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregarReserva.Name = "btnAgregarReserva";
            this.btnAgregarReserva.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregarReserva.Size = new System.Drawing.Size(88, 36);
            this.btnAgregarReserva.TabIndex = 35;
            this.btnAgregarReserva.Text = "Agregar";
            this.btnAgregarReserva.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregarReserva.UseAccentColor = false;
            this.btnAgregarReserva.UseVisualStyleBackColor = true;
            this.btnAgregarReserva.Click += new System.EventHandler(this.btnAgregarReserva_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpiar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLimpiar.Depth = 0;
            this.btnLimpiar.HighEmphasis = true;
            this.btnLimpiar.Icon = null;
            this.btnLimpiar.Location = new System.Drawing.Point(893, 22);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLimpiar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLimpiar.Size = new System.Drawing.Size(79, 36);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLimpiar.UseAccentColor = false;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(63, 115);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(78, 19);
            this.materialLabel5.TabIndex = 33;
            this.materialLabel5.Text = "Habitación";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Pendiente",
            "Cancelado",
            "Finalizado",
            "No Presentado",
            "En Proceso"});
            this.cmbEstado.Location = new System.Drawing.Point(468, 115);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(184, 21);
            this.cmbEstado.TabIndex = 32;
            // 
            // materialLabel44
            // 
            this.materialLabel44.AutoSize = true;
            this.materialLabel44.Depth = 0;
            this.materialLabel44.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel44.Location = new System.Drawing.Point(369, 27);
            this.materialLabel44.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel44.Name = "materialLabel44";
            this.materialLabel44.Size = new System.Drawing.Size(93, 19);
            this.materialLabel44.TabIndex = 31;
            this.materialLabel44.Text = "# Huéspedes";
            // 
            // materialLabel43
            // 
            this.materialLabel43.AutoSize = true;
            this.materialLabel43.Depth = 0;
            this.materialLabel43.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel43.Location = new System.Drawing.Point(413, 70);
            this.materialLabel43.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel43.Name = "materialLabel43";
            this.materialLabel43.Size = new System.Drawing.Size(49, 19);
            this.materialLabel43.TabIndex = 30;
            this.materialLabel43.Text = "Cliente";
            // 
            // materialLabel42
            // 
            this.materialLabel42.AutoSize = true;
            this.materialLabel42.Depth = 0;
            this.materialLabel42.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel42.Location = new System.Drawing.Point(412, 118);
            this.materialLabel42.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel42.Name = "materialLabel42";
            this.materialLabel42.Size = new System.Drawing.Size(50, 19);
            this.materialLabel42.TabIndex = 29;
            this.materialLabel42.Text = "Estado";
            // 
            // materialLabel41
            // 
            this.materialLabel41.AutoSize = true;
            this.materialLabel41.Depth = 0;
            this.materialLabel41.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel41.Location = new System.Drawing.Point(129, 32);
            this.materialLabel41.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel41.Name = "materialLabel41";
            this.materialLabel41.Size = new System.Drawing.Size(56, 19);
            this.materialLabel41.TabIndex = 28;
            this.materialLabel41.Text = "Entrada";
            // 
            // materialLabel40
            // 
            this.materialLabel40.AutoSize = true;
            this.materialLabel40.Depth = 0;
            this.materialLabel40.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel40.Location = new System.Drawing.Point(129, 77);
            this.materialLabel40.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel40.Name = "materialLabel40";
            this.materialLabel40.Size = new System.Drawing.Size(46, 19);
            this.materialLabel40.TabIndex = 27;
            this.materialLabel40.Text = "Salida";
            // 
            // materialLabel39
            // 
            this.materialLabel39.AutoSize = true;
            this.materialLabel39.Depth = 0;
            this.materialLabel39.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel39.Location = new System.Drawing.Point(16, 32);
            this.materialLabel39.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel39.Name = "materialLabel39";
            this.materialLabel39.Size = new System.Drawing.Size(14, 19);
            this.materialLabel39.TabIndex = 26;
            this.materialLabel39.Text = "Id";
            // 
            // dtpSalida
            // 
            this.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSalida.Location = new System.Drawing.Point(203, 72);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(138, 20);
            this.dtpSalida.TabIndex = 25;
            this.dtpSalida.Value = new System.DateTime(2024, 6, 18, 0, 0, 0, 0);
            // 
            // dtpEntrada
            // 
            this.dtpEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntrada.Location = new System.Drawing.Point(203, 27);
            this.dtpEntrada.Name = "dtpEntrada";
            this.dtpEntrada.Size = new System.Drawing.Size(138, 20);
            this.dtpEntrada.TabIndex = 24;
            this.dtpEntrada.Value = new System.DateTime(2024, 6, 18, 0, 0, 0, 0);
            // 
            // cmbHabitaciones
            // 
            this.cmbHabitaciones.FormattingEnabled = true;
            this.cmbHabitaciones.Location = new System.Drawing.Point(147, 112);
            this.cmbHabitaciones.Name = "cmbHabitaciones";
            this.cmbHabitaciones.Size = new System.Drawing.Size(214, 21);
            this.cmbHabitaciones.TabIndex = 23;
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(468, 67);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(214, 21);
            this.cmbClientes.TabIndex = 22;
            // 
            // lblIdReserva
            // 
            this.lblIdReserva.AutoSize = true;
            this.lblIdReserva.Location = new System.Drawing.Point(36, 32);
            this.lblIdReserva.Name = "lblIdReserva";
            this.lblIdReserva.Size = new System.Drawing.Size(0, 13);
            this.lblIdReserva.TabIndex = 21;
            // 
            // txtNumeroHuespedes
            // 
            this.txtNumeroHuespedes.Location = new System.Drawing.Point(468, 26);
            this.txtNumeroHuespedes.Name = "txtNumeroHuespedes";
            this.txtNumeroHuespedes.Size = new System.Drawing.Size(214, 20);
            this.txtNumeroHuespedes.TabIndex = 18;
            // 
            // Reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel12);
            this.Name = "Reservas";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservas";
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        private MaterialSkin.Controls.MaterialLabel materialLabel28;
        private MaterialSkin.Controls.MaterialButton btnBuscarReserva;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DataGridView dataGridViewReservas;
        private System.Windows.Forms.TextBox txtBuscarReserva;
        private System.Windows.Forms.Panel panel12;
        private MaterialSkin.Controls.MaterialButton btnLimpiar;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.ComboBox cmbEstado;
        private MaterialSkin.Controls.MaterialLabel materialLabel44;
        private MaterialSkin.Controls.MaterialLabel materialLabel43;
        private MaterialSkin.Controls.MaterialLabel materialLabel42;
        private MaterialSkin.Controls.MaterialLabel materialLabel41;
        private MaterialSkin.Controls.MaterialLabel materialLabel40;
        private MaterialSkin.Controls.MaterialLabel materialLabel39;
        private System.Windows.Forms.DateTimePicker dtpSalida;
        private System.Windows.Forms.DateTimePicker dtpEntrada;
        private System.Windows.Forms.ComboBox cmbHabitaciones;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label lblIdReserva;
        private System.Windows.Forms.TextBox txtNumeroHuespedes;
        private MaterialSkin.Controls.MaterialButton btnEliminarReserva;
        private MaterialSkin.Controls.MaterialButton btnActualizarReserva;
        private MaterialSkin.Controls.MaterialButton btnAgregarReserva;
    }
}