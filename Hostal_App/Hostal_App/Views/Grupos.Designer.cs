namespace Hostal_App.Views
{
    partial class Grupos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialLabel52 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBuscarGrupo = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewGrupos = new System.Windows.Forms.DataGridView();
            this.txtBuscarGrupo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEliminarGrupo = new MaterialSkin.Controls.MaterialButton();
            this.btnActualizarGrupo = new MaterialSkin.Controls.MaterialButton();
            this.btnAgregarGrupo = new MaterialSkin.Controls.MaterialButton();
            this.btnLimpiar = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel18 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel17 = new MaterialSkin.Controls.MaterialLabel();
            this.lblIdGrupo = new System.Windows.Forms.Label();
            this.txtNombreGrupo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupos)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.materialLabel52);
            this.panel1.Controls.Add(this.btnBuscarGrupo);
            this.panel1.Controls.Add(this.materialLabel8);
            this.panel1.Controls.Add(this.dataGridViewGrupos);
            this.panel1.Controls.Add(this.txtBuscarGrupo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 249);
            this.panel1.TabIndex = 31;
            // 
            // materialLabel52
            // 
            this.materialLabel52.AutoSize = true;
            this.materialLabel52.Depth = 0;
            this.materialLabel52.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel52.Location = new System.Drawing.Point(867, 56);
            this.materialLabel52.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel52.Name = "materialLabel52";
            this.materialLabel52.Size = new System.Drawing.Size(52, 19);
            this.materialLabel52.TabIndex = 12;
            this.materialLabel52.Text = "Grupos";
            // 
            // btnBuscarGrupo
            // 
            this.btnBuscarGrupo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscarGrupo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuscarGrupo.Depth = 0;
            this.btnBuscarGrupo.HighEmphasis = true;
            this.btnBuscarGrupo.Icon = null;
            this.btnBuscarGrupo.Location = new System.Drawing.Point(299, 23);
            this.btnBuscarGrupo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuscarGrupo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscarGrupo.Name = "btnBuscarGrupo";
            this.btnBuscarGrupo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBuscarGrupo.Size = new System.Drawing.Size(77, 36);
            this.btnBuscarGrupo.TabIndex = 11;
            this.btnBuscarGrupo.Text = "Buscar";
            this.btnBuscarGrupo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuscarGrupo.UseAccentColor = false;
            this.btnBuscarGrupo.UseVisualStyleBackColor = true;
            this.btnBuscarGrupo.Click += new System.EventHandler(this.btnBuscarGrupo_Click);
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.Location = new System.Drawing.Point(16, 33);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(50, 19);
            this.materialLabel8.TabIndex = 9;
            this.materialLabel8.Text = "Buscar";
            // 
            // dataGridViewGrupos
            // 
            this.dataGridViewGrupos.AllowUserToAddRows = false;
            this.dataGridViewGrupos.AllowUserToDeleteRows = false;
            this.dataGridViewGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGrupos.Location = new System.Drawing.Point(19, 79);
            this.dataGridViewGrupos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewGrupos.Name = "dataGridViewGrupos";
            this.dataGridViewGrupos.ReadOnly = true;
            this.dataGridViewGrupos.Size = new System.Drawing.Size(900, 150);
            this.dataGridViewGrupos.TabIndex = 0;
            this.dataGridViewGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGrupos_CellClick);
            // 
            // txtBuscarGrupo
            // 
            this.txtBuscarGrupo.Location = new System.Drawing.Point(104, 30);
            this.txtBuscarGrupo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBuscarGrupo.Name = "txtBuscarGrupo";
            this.txtBuscarGrupo.Size = new System.Drawing.Size(164, 20);
            this.txtBuscarGrupo.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.btnEliminarGrupo);
            this.panel2.Controls.Add(this.btnActualizarGrupo);
            this.panel2.Controls.Add(this.btnAgregarGrupo);
            this.panel2.Controls.Add(this.btnLimpiar);
            this.panel2.Controls.Add(this.materialLabel18);
            this.panel2.Controls.Add(this.materialLabel17);
            this.panel2.Controls.Add(this.lblIdGrupo);
            this.panel2.Controls.Add(this.txtNombreGrupo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 234);
            this.panel2.TabIndex = 30;
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminarGrupo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEliminarGrupo.Depth = 0;
            this.btnEliminarGrupo.HighEmphasis = true;
            this.btnEliminarGrupo.Icon = null;
            this.btnEliminarGrupo.Location = new System.Drawing.Point(319, 71);
            this.btnEliminarGrupo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEliminarGrupo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEliminarGrupo.Size = new System.Drawing.Size(88, 36);
            this.btnEliminarGrupo.TabIndex = 34;
            this.btnEliminarGrupo.Text = "Eliminar";
            this.btnEliminarGrupo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEliminarGrupo.UseAccentColor = false;
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnActualizarGrupo
            // 
            this.btnActualizarGrupo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActualizarGrupo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnActualizarGrupo.Depth = 0;
            this.btnActualizarGrupo.HighEmphasis = true;
            this.btnActualizarGrupo.Icon = null;
            this.btnActualizarGrupo.Location = new System.Drawing.Point(181, 71);
            this.btnActualizarGrupo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnActualizarGrupo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnActualizarGrupo.Name = "btnActualizarGrupo";
            this.btnActualizarGrupo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnActualizarGrupo.Size = new System.Drawing.Size(109, 36);
            this.btnActualizarGrupo.TabIndex = 33;
            this.btnActualizarGrupo.Text = "Actualizar";
            this.btnActualizarGrupo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnActualizarGrupo.UseAccentColor = false;
            this.btnActualizarGrupo.UseVisualStyleBackColor = true;
            this.btnActualizarGrupo.Click += new System.EventHandler(this.btnActualizarGrupo_Click);
            // 
            // btnAgregarGrupo
            // 
            this.btnAgregarGrupo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarGrupo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregarGrupo.Depth = 0;
            this.btnAgregarGrupo.HighEmphasis = true;
            this.btnAgregarGrupo.Icon = null;
            this.btnAgregarGrupo.Location = new System.Drawing.Point(66, 71);
            this.btnAgregarGrupo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregarGrupo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregarGrupo.Name = "btnAgregarGrupo";
            this.btnAgregarGrupo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregarGrupo.Size = new System.Drawing.Size(88, 36);
            this.btnAgregarGrupo.TabIndex = 32;
            this.btnAgregarGrupo.Text = "Agregar";
            this.btnAgregarGrupo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregarGrupo.UseAccentColor = false;
            this.btnAgregarGrupo.UseVisualStyleBackColor = true;
            this.btnAgregarGrupo.Click += new System.EventHandler(this.btnAgregarGrupo_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpiar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLimpiar.Depth = 0;
            this.btnLimpiar.HighEmphasis = true;
            this.btnLimpiar.Icon = null;
            this.btnLimpiar.Location = new System.Drawing.Point(883, 71);
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
            // materialLabel18
            // 
            this.materialLabel18.AutoSize = true;
            this.materialLabel18.Depth = 0;
            this.materialLabel18.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel18.Location = new System.Drawing.Point(16, 23);
            this.materialLabel18.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel18.Name = "materialLabel18";
            this.materialLabel18.Size = new System.Drawing.Size(14, 19);
            this.materialLabel18.TabIndex = 22;
            this.materialLabel18.Text = "Id";
            // 
            // materialLabel17
            // 
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.Depth = 0;
            this.materialLabel17.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel17.Location = new System.Drawing.Point(88, 22);
            this.materialLabel17.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.Size = new System.Drawing.Size(44, 19);
            this.materialLabel17.TabIndex = 10;
            this.materialLabel17.Text = "Grupo";
            // 
            // lblIdGrupo
            // 
            this.lblIdGrupo.AutoSize = true;
            this.lblIdGrupo.Location = new System.Drawing.Point(36, 26);
            this.lblIdGrupo.Name = "lblIdGrupo";
            this.lblIdGrupo.Size = new System.Drawing.Size(0, 13);
            this.lblIdGrupo.TabIndex = 21;
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.Location = new System.Drawing.Point(154, 19);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(214, 20);
            this.txtNombreGrupo.TabIndex = 16;
            // 
            // Grupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Grupos";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel52;
        private MaterialSkin.Controls.MaterialButton btnBuscarGrupo;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private System.Windows.Forms.DataGridView dataGridViewGrupos;
        private System.Windows.Forms.TextBox txtBuscarGrupo;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialButton btnLimpiar;
        private MaterialSkin.Controls.MaterialLabel materialLabel18;
        private MaterialSkin.Controls.MaterialLabel materialLabel17;
        private System.Windows.Forms.Label lblIdGrupo;
        private System.Windows.Forms.TextBox txtNombreGrupo;
        private MaterialSkin.Controls.MaterialButton btnEliminarGrupo;
        private MaterialSkin.Controls.MaterialButton btnActualizarGrupo;
        private MaterialSkin.Controls.MaterialButton btnAgregarGrupo;
    }
}