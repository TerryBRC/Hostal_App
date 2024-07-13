namespace Hostal_App.Views
{
    partial class Habitaciones
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
            this.panel9 = new System.Windows.Forms.Panel();
            this.materialLabel29 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBuscarHabitacion = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewH = new System.Windows.Forms.DataGridView();
            this.txtBuscarH = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnEliminarHabitacion = new MaterialSkin.Controls.MaterialButton();
            this.btnActualizarHabitacion = new MaterialSkin.Controls.MaterialButton();
            this.btnAgregarHabitacion = new MaterialSkin.Controls.MaterialButton();
            this.btnLimpiar = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel38 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel37 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel36 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel35 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel34 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.ckbDisponible = new System.Windows.Forms.CheckBox();
            this.lblIdH = new System.Windows.Forms.Label();
            this.txtPrecioXNoche = new System.Windows.Forms.TextBox();
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewH)).BeginInit();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Gainsboro;
            this.panel9.Controls.Add(this.materialLabel29);
            this.panel9.Controls.Add(this.btnBuscarHabitacion);
            this.panel9.Controls.Add(this.materialLabel3);
            this.panel9.Controls.Add(this.dataGridViewH);
            this.panel9.Controls.Add(this.txtBuscarH);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 64);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(994, 236);
            this.panel9.TabIndex = 31;
            // 
            // materialLabel29
            // 
            this.materialLabel29.AutoSize = true;
            this.materialLabel29.Depth = 0;
            this.materialLabel29.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel29.Location = new System.Drawing.Point(825, 56);
            this.materialLabel29.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel29.Name = "materialLabel29";
            this.materialLabel29.Size = new System.Drawing.Size(94, 19);
            this.materialLabel29.TabIndex = 12;
            this.materialLabel29.Text = "Habitaciones";
            // 
            // btnBuscarHabitacion
            // 
            this.btnBuscarHabitacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarHabitacion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscarHabitacion.Depth = 0;
            this.btnBuscarHabitacion.HighEmphasis = true;
            this.btnBuscarHabitacion.Icon = null;
            this.btnBuscarHabitacion.Location = new System.Drawing.Point(299, 23);
            this.btnBuscarHabitacion.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscarHabitacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscarHabitacion.Name = "btnBuscarHabitacion";
            this.btnBuscarHabitacion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscarHabitacion.Size = new System.Drawing.Size(77, 36);
            this.btnBuscarHabitacion.TabIndex = 11;
            this.btnBuscarHabitacion.Text = "Buscar";
            this.btnBuscarHabitacion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscarHabitacion.UseAccentColor = false;
            this.btnBuscarHabitacion.UseVisualStyleBackColor = true;
            this.btnBuscarHabitacion.Click += new System.EventHandler(this.btnBuscarHabitacion_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(16, 33);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(50, 19);
            this.materialLabel3.TabIndex = 9;
            this.materialLabel3.Text = "Buscar";
            // 
            // dataGridViewH
            // 
            this.dataGridViewH.AllowUserToAddRows = false;
            this.dataGridViewH.AllowUserToDeleteRows = false;
            this.dataGridViewH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewH.Location = new System.Drawing.Point(19, 79);
            this.dataGridViewH.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewH.Name = "dataGridViewH";
            this.dataGridViewH.ReadOnly = true;
            this.dataGridViewH.Size = new System.Drawing.Size(900, 150);
            this.dataGridViewH.TabIndex = 0;
            this.dataGridViewH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewH_CellClick);
            // 
            // txtBuscarH
            // 
            this.txtBuscarH.Location = new System.Drawing.Point(104, 30);
            this.txtBuscarH.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBuscarH.Name = "txtBuscarH";
            this.txtBuscarH.Size = new System.Drawing.Size(164, 20);
            this.txtBuscarH.TabIndex = 6;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Gainsboro;
            this.panel10.Controls.Add(this.btnEliminarHabitacion);
            this.panel10.Controls.Add(this.btnActualizarHabitacion);
            this.panel10.Controls.Add(this.btnAgregarHabitacion);
            this.panel10.Controls.Add(this.btnLimpiar);
            this.panel10.Controls.Add(this.materialLabel38);
            this.panel10.Controls.Add(this.materialLabel37);
            this.panel10.Controls.Add(this.materialLabel36);
            this.panel10.Controls.Add(this.materialLabel35);
            this.panel10.Controls.Add(this.materialLabel34);
            this.panel10.Controls.Add(this.cmbTipoHabitacion);
            this.panel10.Controls.Add(this.ckbDisponible);
            this.panel10.Controls.Add(this.lblIdH);
            this.panel10.Controls.Add(this.txtPrecioXNoche);
            this.panel10.Controls.Add(this.txtCapacidad);
            this.panel10.Controls.Add(this.txtNumero);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(3, 300);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(994, 247);
            this.panel10.TabIndex = 30;
            // 
            // btnEliminarHabitacion
            // 
            this.btnEliminarHabitacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminarHabitacion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEliminarHabitacion.Depth = 0;
            this.btnEliminarHabitacion.HighEmphasis = true;
            this.btnEliminarHabitacion.Icon = null;
            this.btnEliminarHabitacion.Location = new System.Drawing.Point(383, 140);
            this.btnEliminarHabitacion.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEliminarHabitacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEliminarHabitacion.Name = "btnEliminarHabitacion";
            this.btnEliminarHabitacion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEliminarHabitacion.Size = new System.Drawing.Size(88, 36);
            this.btnEliminarHabitacion.TabIndex = 37;
            this.btnEliminarHabitacion.Text = "Eliminar";
            this.btnEliminarHabitacion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEliminarHabitacion.UseAccentColor = false;
            this.btnEliminarHabitacion.UseVisualStyleBackColor = true;
            this.btnEliminarHabitacion.Click += new System.EventHandler(this.btnEliminarHabitacion_Click);
            // 
            // btnActualizarHabitacion
            // 
            this.btnActualizarHabitacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarHabitacion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnActualizarHabitacion.Depth = 0;
            this.btnActualizarHabitacion.HighEmphasis = true;
            this.btnActualizarHabitacion.Icon = null;
            this.btnActualizarHabitacion.Location = new System.Drawing.Point(245, 140);
            this.btnActualizarHabitacion.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnActualizarHabitacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActualizarHabitacion.Name = "btnActualizarHabitacion";
            this.btnActualizarHabitacion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnActualizarHabitacion.Size = new System.Drawing.Size(109, 36);
            this.btnActualizarHabitacion.TabIndex = 36;
            this.btnActualizarHabitacion.Text = "Actualizar";
            this.btnActualizarHabitacion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnActualizarHabitacion.UseAccentColor = false;
            this.btnActualizarHabitacion.UseVisualStyleBackColor = true;
            this.btnActualizarHabitacion.Click += new System.EventHandler(this.btnActualizarHabitacion_Click);
            // 
            // btnAgregarHabitacion
            // 
            this.btnAgregarHabitacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarHabitacion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregarHabitacion.Depth = 0;
            this.btnAgregarHabitacion.HighEmphasis = true;
            this.btnAgregarHabitacion.Icon = null;
            this.btnAgregarHabitacion.Location = new System.Drawing.Point(130, 140);
            this.btnAgregarHabitacion.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregarHabitacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregarHabitacion.Name = "btnAgregarHabitacion";
            this.btnAgregarHabitacion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregarHabitacion.Size = new System.Drawing.Size(88, 36);
            this.btnAgregarHabitacion.TabIndex = 35;
            this.btnAgregarHabitacion.Text = "Agregar";
            this.btnAgregarHabitacion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregarHabitacion.UseAccentColor = false;
            this.btnAgregarHabitacion.UseVisualStyleBackColor = true;
            this.btnAgregarHabitacion.Click += new System.EventHandler(this.btnAgregarHabitacion_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpiar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLimpiar.Depth = 0;
            this.btnLimpiar.HighEmphasis = true;
            this.btnLimpiar.Icon = null;
            this.btnLimpiar.Location = new System.Drawing.Point(891, 114);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLimpiar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLimpiar.Size = new System.Drawing.Size(79, 36);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLimpiar.UseAccentColor = false;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // materialLabel38
            // 
            this.materialLabel38.AutoSize = true;
            this.materialLabel38.Depth = 0;
            this.materialLabel38.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel38.Location = new System.Drawing.Point(489, 20);
            this.materialLabel38.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel38.Name = "materialLabel38";
            this.materialLabel38.Size = new System.Drawing.Size(121, 19);
            this.materialLabel38.TabIndex = 28;
            this.materialLabel38.Text = "Precio por Noche";
            // 
            // materialLabel37
            // 
            this.materialLabel37.AutoSize = true;
            this.materialLabel37.Depth = 0;
            this.materialLabel37.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel37.Location = new System.Drawing.Point(475, 65);
            this.materialLabel37.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel37.Name = "materialLabel37";
            this.materialLabel37.Size = new System.Drawing.Size(135, 19);
            this.materialLabel37.TabIndex = 27;
            this.materialLabel37.Text = "Tipo de Habitación";
            // 
            // materialLabel36
            // 
            this.materialLabel36.AutoSize = true;
            this.materialLabel36.Depth = 0;
            this.materialLabel36.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel36.Location = new System.Drawing.Point(76, 67);
            this.materialLabel36.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel36.Name = "materialLabel36";
            this.materialLabel36.Size = new System.Drawing.Size(77, 19);
            this.materialLabel36.TabIndex = 26;
            this.materialLabel36.Text = "Capacidad";
            // 
            // materialLabel35
            // 
            this.materialLabel35.AutoSize = true;
            this.materialLabel35.Depth = 0;
            this.materialLabel35.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel35.Location = new System.Drawing.Point(101, 20);
            this.materialLabel35.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel35.Name = "materialLabel35";
            this.materialLabel35.Size = new System.Drawing.Size(57, 19);
            this.materialLabel35.TabIndex = 25;
            this.materialLabel35.Text = "Número";
            // 
            // materialLabel34
            // 
            this.materialLabel34.AutoSize = true;
            this.materialLabel34.Depth = 0;
            this.materialLabel34.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel34.Location = new System.Drawing.Point(16, 23);
            this.materialLabel34.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel34.Name = "materialLabel34";
            this.materialLabel34.Size = new System.Drawing.Size(14, 19);
            this.materialLabel34.TabIndex = 24;
            this.materialLabel34.Text = "Id";
            // 
            // cmbTipoHabitacion
            // 
            this.cmbTipoHabitacion.FormattingEnabled = true;
            this.cmbTipoHabitacion.Location = new System.Drawing.Point(648, 62);
            this.cmbTipoHabitacion.Name = "cmbTipoHabitacion";
            this.cmbTipoHabitacion.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoHabitacion.TabIndex = 23;
            // 
            // ckbDisponible
            // 
            this.ckbDisponible.AutoSize = true;
            this.ckbDisponible.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbDisponible.Location = new System.Drawing.Point(79, 103);
            this.ckbDisponible.Name = "ckbDisponible";
            this.ckbDisponible.Size = new System.Drawing.Size(91, 18);
            this.ckbDisponible.TabIndex = 22;
            this.ckbDisponible.Text = "Disponible";
            this.ckbDisponible.UseVisualStyleBackColor = true;
            // 
            // lblIdH
            // 
            this.lblIdH.AutoSize = true;
            this.lblIdH.Location = new System.Drawing.Point(36, 26);
            this.lblIdH.Name = "lblIdH";
            this.lblIdH.Size = new System.Drawing.Size(0, 13);
            this.lblIdH.TabIndex = 21;
            // 
            // txtPrecioXNoche
            // 
            this.txtPrecioXNoche.Location = new System.Drawing.Point(627, 17);
            this.txtPrecioXNoche.Name = "txtPrecioXNoche";
            this.txtPrecioXNoche.Size = new System.Drawing.Size(192, 20);
            this.txtPrecioXNoche.TabIndex = 18;
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Location = new System.Drawing.Point(198, 62);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(192, 20);
            this.txtCapacidad.TabIndex = 17;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(198, 17);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(192, 20);
            this.txtNumero.TabIndex = 16;
            // 
            // Habitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel10);
            this.Name = "Habitaciones";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habitaciones";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewH)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel29;
        private MaterialSkin.Controls.MaterialButton btnBuscarHabitacion;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.DataGridView dataGridViewH;
        private System.Windows.Forms.TextBox txtBuscarH;
        private System.Windows.Forms.Panel panel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel38;
        private MaterialSkin.Controls.MaterialLabel materialLabel37;
        private MaterialSkin.Controls.MaterialLabel materialLabel36;
        private MaterialSkin.Controls.MaterialLabel materialLabel35;
        private MaterialSkin.Controls.MaterialLabel materialLabel34;
        private System.Windows.Forms.ComboBox cmbTipoHabitacion;
        private System.Windows.Forms.CheckBox ckbDisponible;
        private System.Windows.Forms.Label lblIdH;
        private System.Windows.Forms.TextBox txtPrecioXNoche;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.TextBox txtNumero;
        private MaterialSkin.Controls.MaterialButton btnLimpiar;
        private MaterialSkin.Controls.MaterialButton btnEliminarHabitacion;
        private MaterialSkin.Controls.MaterialButton btnActualizarHabitacion;
        private MaterialSkin.Controls.MaterialButton btnAgregarHabitacion;
    }
}