namespace Hostal_App.Views
{
    partial class GruposPermisos
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
            this.panel15 = new System.Windows.Forms.Panel();
            this.materialLabel53 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBuscarGrupoPermiso = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewGruposPermisos = new System.Windows.Forms.DataGridView();
            this.txtBuscarGrupoPermiso = new System.Windows.Forms.TextBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btnEliminarGrupoPermiso = new MaterialSkin.Controls.MaterialButton();
            this.btnAgregarGrupoPermiso = new MaterialSkin.Controls.MaterialButton();
            this.btnLimpiar = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbPermisos = new System.Windows.Forms.ComboBox();
            this.cmbGrupos = new System.Windows.Forms.ComboBox();
            this.lblIdPermisosGrupos = new System.Windows.Forms.Label();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGruposPermisos)).BeginInit();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Gainsboro;
            this.panel15.Controls.Add(this.materialLabel53);
            this.panel15.Controls.Add(this.btnBuscarGrupoPermiso);
            this.panel15.Controls.Add(this.materialLabel9);
            this.panel15.Controls.Add(this.dataGridViewGruposPermisos);
            this.panel15.Controls.Add(this.txtBuscarGrupoPermiso);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(3, 64);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(994, 245);
            this.panel15.TabIndex = 31;
            // 
            // materialLabel53
            // 
            this.materialLabel53.AutoSize = true;
            this.materialLabel53.Depth = 0;
            this.materialLabel53.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel53.Location = new System.Drawing.Point(794, 56);
            this.materialLabel53.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel53.Name = "materialLabel53";
            this.materialLabel53.Size = new System.Drawing.Size(125, 19);
            this.materialLabel53.TabIndex = 12;
            this.materialLabel53.Text = "Grupos/Permisos";
            // 
            // btnBuscarGrupoPermiso
            // 
            this.btnBuscarGrupoPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarGrupoPermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscarGrupoPermiso.Depth = 0;
            this.btnBuscarGrupoPermiso.HighEmphasis = true;
            this.btnBuscarGrupoPermiso.Icon = null;
            this.btnBuscarGrupoPermiso.Location = new System.Drawing.Point(299, 23);
            this.btnBuscarGrupoPermiso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscarGrupoPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscarGrupoPermiso.Name = "btnBuscarGrupoPermiso";
            this.btnBuscarGrupoPermiso.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscarGrupoPermiso.Size = new System.Drawing.Size(77, 36);
            this.btnBuscarGrupoPermiso.TabIndex = 11;
            this.btnBuscarGrupoPermiso.Text = "Buscar";
            this.btnBuscarGrupoPermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscarGrupoPermiso.UseAccentColor = false;
            this.btnBuscarGrupoPermiso.UseVisualStyleBackColor = true;
            this.btnBuscarGrupoPermiso.Click += new System.EventHandler(this.btnBuscarGrupoPermiso_Click);
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.Location = new System.Drawing.Point(16, 33);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(50, 19);
            this.materialLabel9.TabIndex = 9;
            this.materialLabel9.Text = "Buscar";
            // 
            // dataGridViewGruposPermisos
            // 
            this.dataGridViewGruposPermisos.AllowUserToAddRows = false;
            this.dataGridViewGruposPermisos.AllowUserToDeleteRows = false;
            this.dataGridViewGruposPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGruposPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGruposPermisos.Location = new System.Drawing.Point(19, 79);
            this.dataGridViewGruposPermisos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewGruposPermisos.Name = "dataGridViewGruposPermisos";
            this.dataGridViewGruposPermisos.ReadOnly = true;
            this.dataGridViewGruposPermisos.Size = new System.Drawing.Size(900, 150);
            this.dataGridViewGruposPermisos.TabIndex = 0;
            this.dataGridViewGruposPermisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGruposPermisos_CellClick);
            // 
            // txtBuscarGrupoPermiso
            // 
            this.txtBuscarGrupoPermiso.Location = new System.Drawing.Point(104, 30);
            this.txtBuscarGrupoPermiso.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBuscarGrupoPermiso.Name = "txtBuscarGrupoPermiso";
            this.txtBuscarGrupoPermiso.Size = new System.Drawing.Size(164, 20);
            this.txtBuscarGrupoPermiso.TabIndex = 6;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.Gainsboro;
            this.panel16.Controls.Add(this.btnEliminarGrupoPermiso);
            this.panel16.Controls.Add(this.btnAgregarGrupoPermiso);
            this.panel16.Controls.Add(this.btnLimpiar);
            this.panel16.Controls.Add(this.materialLabel16);
            this.panel16.Controls.Add(this.materialLabel15);
            this.panel16.Controls.Add(this.materialLabel14);
            this.panel16.Controls.Add(this.cmbPermisos);
            this.panel16.Controls.Add(this.cmbGrupos);
            this.panel16.Controls.Add(this.lblIdPermisosGrupos);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel16.Location = new System.Drawing.Point(3, 309);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(994, 238);
            this.panel16.TabIndex = 30;
            // 
            // btnEliminarGrupoPermiso
            // 
            this.btnEliminarGrupoPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminarGrupoPermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEliminarGrupoPermiso.Depth = 0;
            this.btnEliminarGrupoPermiso.HighEmphasis = true;
            this.btnEliminarGrupoPermiso.Icon = null;
            this.btnEliminarGrupoPermiso.Location = new System.Drawing.Point(305, 69);
            this.btnEliminarGrupoPermiso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEliminarGrupoPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEliminarGrupoPermiso.Name = "btnEliminarGrupoPermiso";
            this.btnEliminarGrupoPermiso.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEliminarGrupoPermiso.Size = new System.Drawing.Size(88, 36);
            this.btnEliminarGrupoPermiso.TabIndex = 37;
            this.btnEliminarGrupoPermiso.Text = "Eliminar";
            this.btnEliminarGrupoPermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEliminarGrupoPermiso.UseAccentColor = false;
            this.btnEliminarGrupoPermiso.UseVisualStyleBackColor = true;
            this.btnEliminarGrupoPermiso.Click += new System.EventHandler(this.btnEliminarGrupoPermiso_Click);
            // 
            // btnAgregarGrupoPermiso
            // 
            this.btnAgregarGrupoPermiso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarGrupoPermiso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregarGrupoPermiso.Depth = 0;
            this.btnAgregarGrupoPermiso.HighEmphasis = true;
            this.btnAgregarGrupoPermiso.Icon = null;
            this.btnAgregarGrupoPermiso.Location = new System.Drawing.Point(180, 69);
            this.btnAgregarGrupoPermiso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregarGrupoPermiso.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregarGrupoPermiso.Name = "btnAgregarGrupoPermiso";
            this.btnAgregarGrupoPermiso.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregarGrupoPermiso.Size = new System.Drawing.Size(88, 36);
            this.btnAgregarGrupoPermiso.TabIndex = 35;
            this.btnAgregarGrupoPermiso.Text = "Agregar";
            this.btnAgregarGrupoPermiso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregarGrupoPermiso.UseAccentColor = false;
            this.btnAgregarGrupoPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarGrupoPermiso.Click += new System.EventHandler(this.btnAgregarGrupoPermiso_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpiar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLimpiar.Depth = 0;
            this.btnLimpiar.HighEmphasis = true;
            this.btnLimpiar.Icon = null;
            this.btnLimpiar.Location = new System.Drawing.Point(875, 69);
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
            // materialLabel16
            // 
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.Depth = 0;
            this.materialLabel16.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel16.Location = new System.Drawing.Point(119, 26);
            this.materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(44, 19);
            this.materialLabel16.TabIndex = 26;
            this.materialLabel16.Text = "Grupo";
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel15.Location = new System.Drawing.Point(434, 25);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(59, 19);
            this.materialLabel15.TabIndex = 25;
            this.materialLabel15.Text = "Permiso";
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel14.Location = new System.Drawing.Point(16, 23);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(14, 19);
            this.materialLabel14.TabIndex = 24;
            this.materialLabel14.Text = "Id";
            // 
            // cmbPermisos
            // 
            this.cmbPermisos.FormattingEnabled = true;
            this.cmbPermisos.Location = new System.Drawing.Point(509, 22);
            this.cmbPermisos.Name = "cmbPermisos";
            this.cmbPermisos.Size = new System.Drawing.Size(201, 21);
            this.cmbPermisos.TabIndex = 23;
            // 
            // cmbGrupos
            // 
            this.cmbGrupos.FormattingEnabled = true;
            this.cmbGrupos.Location = new System.Drawing.Point(194, 23);
            this.cmbGrupos.Name = "cmbGrupos";
            this.cmbGrupos.Size = new System.Drawing.Size(201, 21);
            this.cmbGrupos.TabIndex = 22;
            // 
            // lblIdPermisosGrupos
            // 
            this.lblIdPermisosGrupos.AutoSize = true;
            this.lblIdPermisosGrupos.Location = new System.Drawing.Point(36, 26);
            this.lblIdPermisosGrupos.Name = "lblIdPermisosGrupos";
            this.lblIdPermisosGrupos.Size = new System.Drawing.Size(0, 13);
            this.lblIdPermisosGrupos.TabIndex = 21;
            // 
            // GruposPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel16);
            this.Name = "GruposPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GruposPermisos";
            this.Load += new System.EventHandler(this.GruposPermisos_Load);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGruposPermisos)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel15;
        private MaterialSkin.Controls.MaterialLabel materialLabel53;
        private MaterialSkin.Controls.MaterialButton btnBuscarGrupoPermiso;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private System.Windows.Forms.DataGridView dataGridViewGruposPermisos;
        private System.Windows.Forms.TextBox txtBuscarGrupoPermiso;
        private System.Windows.Forms.Panel panel16;
        private MaterialSkin.Controls.MaterialButton btnLimpiar;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private System.Windows.Forms.ComboBox cmbPermisos;
        private System.Windows.Forms.ComboBox cmbGrupos;
        private System.Windows.Forms.Label lblIdPermisosGrupos;
        private MaterialSkin.Controls.MaterialButton btnEliminarGrupoPermiso;
        private MaterialSkin.Controls.MaterialButton btnAgregarGrupoPermiso;
    }
}