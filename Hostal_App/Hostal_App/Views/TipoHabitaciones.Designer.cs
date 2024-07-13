namespace Hostal_App.Views
{
    partial class TipoHabitaciones
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.materialLabel30 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBuscarTH = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewTH = new System.Windows.Forms.DataGridView();
            this.txtBuscarTH = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnEliminarTH = new MaterialSkin.Controls.MaterialButton();
            this.btnActualizarTH = new MaterialSkin.Controls.MaterialButton();
            this.btnAgregarTH = new MaterialSkin.Controls.MaterialButton();
            this.btnLimpiar = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel33 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel32 = new MaterialSkin.Controls.MaterialLabel();
            this.lblIdTH = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTH)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.Controls.Add(this.materialLabel30);
            this.panel7.Controls.Add(this.btnBuscarTH);
            this.panel7.Controls.Add(this.materialLabel4);
            this.panel7.Controls.Add(this.dataGridViewTH);
            this.panel7.Controls.Add(this.txtBuscarTH);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 64);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(994, 236);
            this.panel7.TabIndex = 31;
            // 
            // materialLabel30
            // 
            this.materialLabel30.AutoSize = true;
            this.materialLabel30.Depth = 0;
            this.materialLabel30.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel30.Location = new System.Drawing.Point(768, 56);
            this.materialLabel30.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel30.Name = "materialLabel30";
            this.materialLabel30.Size = new System.Drawing.Size(151, 19);
            this.materialLabel30.TabIndex = 12;
            this.materialLabel30.Text = "Tipo de Habitaciones";
            // 
            // btnBuscarTH
            // 
            this.btnBuscarTH.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarTH.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscarTH.Depth = 0;
            this.btnBuscarTH.HighEmphasis = true;
            this.btnBuscarTH.Icon = null;
            this.btnBuscarTH.Location = new System.Drawing.Point(299, 23);
            this.btnBuscarTH.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscarTH.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscarTH.Name = "btnBuscarTH";
            this.btnBuscarTH.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscarTH.Size = new System.Drawing.Size(77, 36);
            this.btnBuscarTH.TabIndex = 11;
            this.btnBuscarTH.Text = "Buscar";
            this.btnBuscarTH.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscarTH.UseAccentColor = false;
            this.btnBuscarTH.UseVisualStyleBackColor = true;
            this.btnBuscarTH.Click += new System.EventHandler(this.btnBuscarTH_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(16, 33);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(50, 19);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "Buscar";
            // 
            // dataGridViewTH
            // 
            this.dataGridViewTH.AllowUserToAddRows = false;
            this.dataGridViewTH.AllowUserToDeleteRows = false;
            this.dataGridViewTH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTH.Location = new System.Drawing.Point(19, 79);
            this.dataGridViewTH.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewTH.Name = "dataGridViewTH";
            this.dataGridViewTH.ReadOnly = true;
            this.dataGridViewTH.Size = new System.Drawing.Size(900, 150);
            this.dataGridViewTH.TabIndex = 0;
            this.dataGridViewTH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTH_CellClick);
            // 
            // txtBuscarTH
            // 
            this.txtBuscarTH.Location = new System.Drawing.Point(104, 30);
            this.txtBuscarTH.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBuscarTH.Name = "txtBuscarTH";
            this.txtBuscarTH.Size = new System.Drawing.Size(164, 20);
            this.txtBuscarTH.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gainsboro;
            this.panel8.Controls.Add(this.btnEliminarTH);
            this.panel8.Controls.Add(this.btnActualizarTH);
            this.panel8.Controls.Add(this.btnAgregarTH);
            this.panel8.Controls.Add(this.btnLimpiar);
            this.panel8.Controls.Add(this.materialLabel33);
            this.panel8.Controls.Add(this.materialLabel32);
            this.panel8.Controls.Add(this.lblIdTH);
            this.panel8.Controls.Add(this.label46);
            this.panel8.Controls.Add(this.txtDescripcion);
            this.panel8.Controls.Add(this.txtTipo);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(3, 300);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(994, 247);
            this.panel8.TabIndex = 30;
            // 
            // btnEliminarTH
            // 
            this.btnEliminarTH.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminarTH.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEliminarTH.Depth = 0;
            this.btnEliminarTH.HighEmphasis = true;
            this.btnEliminarTH.Icon = null;
            this.btnEliminarTH.Location = new System.Drawing.Point(345, 95);
            this.btnEliminarTH.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEliminarTH.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEliminarTH.Name = "btnEliminarTH";
            this.btnEliminarTH.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEliminarTH.Size = new System.Drawing.Size(88, 36);
            this.btnEliminarTH.TabIndex = 37;
            this.btnEliminarTH.Text = "Eliminar";
            this.btnEliminarTH.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEliminarTH.UseAccentColor = false;
            this.btnEliminarTH.UseVisualStyleBackColor = true;
            this.btnEliminarTH.Click += new System.EventHandler(this.btnEliminarTH_Click);
            // 
            // btnActualizarTH
            // 
            this.btnActualizarTH.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarTH.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnActualizarTH.Depth = 0;
            this.btnActualizarTH.HighEmphasis = true;
            this.btnActualizarTH.Icon = null;
            this.btnActualizarTH.Location = new System.Drawing.Point(207, 95);
            this.btnActualizarTH.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnActualizarTH.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActualizarTH.Name = "btnActualizarTH";
            this.btnActualizarTH.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnActualizarTH.Size = new System.Drawing.Size(109, 36);
            this.btnActualizarTH.TabIndex = 36;
            this.btnActualizarTH.Text = "Actualizar";
            this.btnActualizarTH.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnActualizarTH.UseAccentColor = false;
            this.btnActualizarTH.UseVisualStyleBackColor = true;
            this.btnActualizarTH.Click += new System.EventHandler(this.btnActualizarTH_Click);
            // 
            // btnAgregarTH
            // 
            this.btnAgregarTH.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarTH.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregarTH.Depth = 0;
            this.btnAgregarTH.HighEmphasis = true;
            this.btnAgregarTH.Icon = null;
            this.btnAgregarTH.Location = new System.Drawing.Point(92, 95);
            this.btnAgregarTH.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregarTH.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregarTH.Name = "btnAgregarTH";
            this.btnAgregarTH.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregarTH.Size = new System.Drawing.Size(88, 36);
            this.btnAgregarTH.TabIndex = 35;
            this.btnAgregarTH.Text = "Agregar";
            this.btnAgregarTH.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregarTH.UseAccentColor = false;
            this.btnAgregarTH.UseVisualStyleBackColor = true;
            this.btnAgregarTH.Click += new System.EventHandler(this.btnAgregarTH_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpiar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLimpiar.Depth = 0;
            this.btnLimpiar.HighEmphasis = true;
            this.btnLimpiar.Icon = null;
            this.btnLimpiar.Location = new System.Drawing.Point(868, 95);
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
            // materialLabel33
            // 
            this.materialLabel33.AutoSize = true;
            this.materialLabel33.Depth = 0;
            this.materialLabel33.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel33.Location = new System.Drawing.Point(409, 23);
            this.materialLabel33.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel33.Name = "materialLabel33";
            this.materialLabel33.Size = new System.Drawing.Size(84, 19);
            this.materialLabel33.TabIndex = 23;
            this.materialLabel33.Text = "Descripción";
            // 
            // materialLabel32
            // 
            this.materialLabel32.AutoSize = true;
            this.materialLabel32.Depth = 0;
            this.materialLabel32.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel32.Location = new System.Drawing.Point(168, 23);
            this.materialLabel32.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel32.Name = "materialLabel32";
            this.materialLabel32.Size = new System.Drawing.Size(33, 19);
            this.materialLabel32.TabIndex = 22;
            this.materialLabel32.Text = "Tipo";
            // 
            // lblIdTH
            // 
            this.lblIdTH.AutoSize = true;
            this.lblIdTH.Location = new System.Drawing.Point(57, 14);
            this.lblIdTH.Name = "lblIdTH";
            this.lblIdTH.Size = new System.Drawing.Size(0, 13);
            this.lblIdTH.TabIndex = 21;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(16, 14);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(16, 13);
            this.label46.TabIndex = 13;
            this.label46.Text = "Id";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(347, 45);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(214, 20);
            this.txtDescripcion.TabIndex = 17;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(92, 48);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(214, 20);
            this.txtTipo.TabIndex = 16;
            // 
            // TipoHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel8);
            this.Name = "TipoHabitaciones";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TipoHabitaciones";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTH)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel30;
        private MaterialSkin.Controls.MaterialButton btnBuscarTH;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.DataGridView dataGridViewTH;
        private System.Windows.Forms.TextBox txtBuscarTH;
        private System.Windows.Forms.Panel panel8;
        private MaterialSkin.Controls.MaterialButton btnLimpiar;
        private MaterialSkin.Controls.MaterialLabel materialLabel33;
        private MaterialSkin.Controls.MaterialLabel materialLabel32;
        private System.Windows.Forms.Label lblIdTH;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtTipo;
        private MaterialSkin.Controls.MaterialButton btnEliminarTH;
        private MaterialSkin.Controls.MaterialButton btnActualizarTH;
        private MaterialSkin.Controls.MaterialButton btnAgregarTH;
    }
}