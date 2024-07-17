namespace Hostal_App.Views
{
    partial class Permisos
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.materialLabel51 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBuscarPermiso = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewPermisos = new System.Windows.Forms.DataGridView();
            this.txtBuscarPermiso = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEliminarPermiso = new MaterialSkin.Controls.MaterialButton();
            this.btnActualizarPermiso = new MaterialSkin.Controls.MaterialButton();
            this.btnAgregarPermiso = new MaterialSkin.Controls.MaterialButton();
            this.btnLimpiar = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel20 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel19 = new MaterialSkin.Controls.MaterialLabel();
            this.lblIdPermiso = new System.Windows.Forms.Label();
            this.txtNombrePermiso = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisos)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.materialLabel51);
            this.panel3.Controls.Add(this.btnBuscarPermiso);
            this.panel3.Controls.Add(this.materialLabel7);
            this.panel3.Controls.Add(this.dataGridViewPermisos);
            this.panel3.Controls.Add(this.txtBuscarPermiso);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 236);
            this.panel3.TabIndex = 31;
            // 
            // materialLabel51
            // 
            this.materialLabel51.AutoSize = true;
            this.materialLabel51.Depth = 0;
            this.materialLabel51.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel51.Location = new System.Drawing.Point(852, 56);
            this.materialLabel51.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel51.Name = "materialLabel51";
            this.materialLabel51.Size = new System.Drawing.Size(67, 19);
            this.materialLabel51.TabIndex = 12;
            this.materialLabel51.Text = "Permisos";
            // 
            // btnBuscarPermiso
            // 
            this.btnBuscarPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarPermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscarPermiso.Depth = 0;
            this.btnBuscarPermiso.HighEmphasis = true;
            this.btnBuscarPermiso.Icon = null;
            this.btnBuscarPermiso.Location = new System.Drawing.Point(299, 23);
            this.btnBuscarPermiso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscarPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscarPermiso.Name = "btnBuscarPermiso";
            this.btnBuscarPermiso.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscarPermiso.Size = new System.Drawing.Size(77, 36);
            this.btnBuscarPermiso.TabIndex = 11;
            this.btnBuscarPermiso.Text = "Buscar";
            this.btnBuscarPermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscarPermiso.UseAccentColor = false;
            this.btnBuscarPermiso.UseVisualStyleBackColor = true;
            this.btnBuscarPermiso.Click += new System.EventHandler(this.btnBuscarPermiso_Click);
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(16, 33);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(50, 19);
            this.materialLabel7.TabIndex = 9;
            this.materialLabel7.Text = "Buscar";
            // 
            // dataGridViewPermisos
            // 
            this.dataGridViewPermisos.AllowUserToAddRows = false;
            this.dataGridViewPermisos.AllowUserToDeleteRows = false;
            this.dataGridViewPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPermisos.Location = new System.Drawing.Point(19, 79);
            this.dataGridViewPermisos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewPermisos.Name = "dataGridViewPermisos";
            this.dataGridViewPermisos.ReadOnly = true;
            this.dataGridViewPermisos.Size = new System.Drawing.Size(900, 150);
            this.dataGridViewPermisos.TabIndex = 0;
            this.dataGridViewPermisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPermisos_CellClick);
            // 
            // txtBuscarPermiso
            // 
            this.txtBuscarPermiso.Location = new System.Drawing.Point(104, 30);
            this.txtBuscarPermiso.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBuscarPermiso.Name = "txtBuscarPermiso";
            this.txtBuscarPermiso.Size = new System.Drawing.Size(164, 20);
            this.txtBuscarPermiso.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.materialLabel1);
            this.panel4.Controls.Add(this.txtDescripcion);
            this.panel4.Controls.Add(this.btnEliminarPermiso);
            this.panel4.Controls.Add(this.btnActualizarPermiso);
            this.panel4.Controls.Add(this.btnAgregarPermiso);
            this.panel4.Controls.Add(this.btnLimpiar);
            this.panel4.Controls.Add(this.materialLabel20);
            this.panel4.Controls.Add(this.materialLabel19);
            this.panel4.Controls.Add(this.lblIdPermiso);
            this.panel4.Controls.Add(this.txtNombrePermiso);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 300);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(994, 247);
            this.panel4.TabIndex = 30;
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminarPermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEliminarPermiso.Depth = 0;
            this.btnEliminarPermiso.HighEmphasis = true;
            this.btnEliminarPermiso.Icon = null;
            this.btnEliminarPermiso.Location = new System.Drawing.Point(344, 68);
            this.btnEliminarPermiso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEliminarPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEliminarPermiso.Size = new System.Drawing.Size(88, 36);
            this.btnEliminarPermiso.TabIndex = 37;
            this.btnEliminarPermiso.Text = "Eliminar";
            this.btnEliminarPermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEliminarPermiso.UseAccentColor = false;
            this.btnEliminarPermiso.UseVisualStyleBackColor = true;
            this.btnEliminarPermiso.Click += new System.EventHandler(this.btnEliminarPermiso_Click);
            // 
            // btnActualizarPermiso
            // 
            this.btnActualizarPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarPermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnActualizarPermiso.Depth = 0;
            this.btnActualizarPermiso.HighEmphasis = true;
            this.btnActualizarPermiso.Icon = null;
            this.btnActualizarPermiso.Location = new System.Drawing.Point(206, 68);
            this.btnActualizarPermiso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnActualizarPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActualizarPermiso.Name = "btnActualizarPermiso";
            this.btnActualizarPermiso.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnActualizarPermiso.Size = new System.Drawing.Size(109, 36);
            this.btnActualizarPermiso.TabIndex = 36;
            this.btnActualizarPermiso.Text = "Actualizar";
            this.btnActualizarPermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnActualizarPermiso.UseAccentColor = false;
            this.btnActualizarPermiso.UseVisualStyleBackColor = true;
            this.btnActualizarPermiso.Click += new System.EventHandler(this.btnActualizarPermiso_Click);
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarPermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregarPermiso.Depth = 0;
            this.btnAgregarPermiso.HighEmphasis = true;
            this.btnAgregarPermiso.Icon = null;
            this.btnAgregarPermiso.Location = new System.Drawing.Point(91, 68);
            this.btnAgregarPermiso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregarPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregarPermiso.Size = new System.Drawing.Size(88, 36);
            this.btnAgregarPermiso.TabIndex = 35;
            this.btnAgregarPermiso.Text = "Agregar";
            this.btnAgregarPermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregarPermiso.UseAccentColor = false;
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpiar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLimpiar.Depth = 0;
            this.btnLimpiar.HighEmphasis = true;
            this.btnLimpiar.Icon = null;
            this.btnLimpiar.Location = new System.Drawing.Point(880, 68);
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
            // materialLabel20
            // 
            this.materialLabel20.AutoSize = true;
            this.materialLabel20.Depth = 0;
            this.materialLabel20.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel20.Location = new System.Drawing.Point(120, 18);
            this.materialLabel20.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel20.Name = "materialLabel20";
            this.materialLabel20.Size = new System.Drawing.Size(59, 19);
            this.materialLabel20.TabIndex = 23;
            this.materialLabel20.Text = "Permiso";
            // 
            // materialLabel19
            // 
            this.materialLabel19.AutoSize = true;
            this.materialLabel19.Depth = 0;
            this.materialLabel19.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel19.Location = new System.Drawing.Point(25, 19);
            this.materialLabel19.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel19.Name = "materialLabel19";
            this.materialLabel19.Size = new System.Drawing.Size(14, 19);
            this.materialLabel19.TabIndex = 22;
            this.materialLabel19.Text = "Id";
            // 
            // lblIdPermiso
            // 
            this.lblIdPermiso.AutoSize = true;
            this.lblIdPermiso.Location = new System.Drawing.Point(45, 22);
            this.lblIdPermiso.Name = "lblIdPermiso";
            this.lblIdPermiso.Size = new System.Drawing.Size(0, 13);
            this.lblIdPermiso.TabIndex = 21;
            // 
            // txtNombrePermiso
            // 
            this.txtNombrePermiso.Location = new System.Drawing.Point(201, 15);
            this.txtNombrePermiso.Name = "txtNombrePermiso";
            this.txtNombrePermiso.Size = new System.Drawing.Size(214, 20);
            this.txtNombrePermiso.TabIndex = 16;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(444, 18);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(84, 19);
            this.materialLabel1.TabIndex = 39;
            this.materialLabel1.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(545, 15);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(214, 20);
            this.txtDescripcion.TabIndex = 38;
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Name = "Permisos";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel51;
        private MaterialSkin.Controls.MaterialButton btnBuscarPermiso;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.DataGridView dataGridViewPermisos;
        private System.Windows.Forms.TextBox txtBuscarPermiso;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialButton btnLimpiar;
        private MaterialSkin.Controls.MaterialLabel materialLabel20;
        private MaterialSkin.Controls.MaterialLabel materialLabel19;
        private System.Windows.Forms.Label lblIdPermiso;
        private System.Windows.Forms.TextBox txtNombrePermiso;
        private MaterialSkin.Controls.MaterialButton btnEliminarPermiso;
        private MaterialSkin.Controls.MaterialButton btnActualizarPermiso;
        private MaterialSkin.Controls.MaterialButton btnAgregarPermiso;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}