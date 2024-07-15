namespace Hostal_App
{
    partial class DashboardForm
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeHabitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbPermisos = new System.Windows.Forms.ListBox();
            this.btnBackup = new MaterialSkin.Controls.MaterialButton();
            this.btnRestore = new MaterialSkin.Controls.MaterialButton();
            this.lblrm = new MaterialSkin.Controls.MaterialLabel();
            this.lblrth = new MaterialSkin.Controls.MaterialLabel();
            this.opcionesDeReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(36, 107);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(776, 426);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.Visible = false;
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Location = new System.Drawing.Point(834, 107);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(776, 426);
            this.cartesianChart2.TabIndex = 1;
            this.cartesianChart2.Text = "cartesianChart2";
            this.cartesianChart2.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.reservasToolStripMenuItem,
            this.habitacionesToolStripMenuItem,
            this.tipoDeHabitacionesToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.permisosToolStripMenuItem,
            this.gruposToolStripMenuItem,
            this.gruposPermisosToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.opcionesDeReservaToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 64);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1872, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.reservasToolStripMenuItem.Text = "Reservas";
            this.reservasToolStripMenuItem.Click += new System.EventHandler(this.reservasToolStripMenuItem_Click);
            // 
            // habitacionesToolStripMenuItem
            // 
            this.habitacionesToolStripMenuItem.Name = "habitacionesToolStripMenuItem";
            this.habitacionesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.habitacionesToolStripMenuItem.Text = "Habitaciones";
            this.habitacionesToolStripMenuItem.Click += new System.EventHandler(this.habitacionesToolStripMenuItem_Click);
            // 
            // tipoDeHabitacionesToolStripMenuItem
            // 
            this.tipoDeHabitacionesToolStripMenuItem.Name = "tipoDeHabitacionesToolStripMenuItem";
            this.tipoDeHabitacionesToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.tipoDeHabitacionesToolStripMenuItem.Text = "Tipo de Habitaciones";
            this.tipoDeHabitacionesToolStripMenuItem.Click += new System.EventHandler(this.tipoDeHabitacionesToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.permisosToolStripMenuItem.Text = "Permisos";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.gruposToolStripMenuItem.Text = "Grupos";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // gruposPermisosToolStripMenuItem
            // 
            this.gruposPermisosToolStripMenuItem.Name = "gruposPermisosToolStripMenuItem";
            this.gruposPermisosToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.gruposPermisosToolStripMenuItem.Text = "Grupos/Permisos";
            this.gruposPermisosToolStripMenuItem.Click += new System.EventHandler(this.gruposPermisosToolStripMenuItem_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.informesToolStripMenuItem.Text = "Reportes";
            this.informesToolStripMenuItem.Click += new System.EventHandler(this.informesToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // lbPermisos
            // 
            this.lbPermisos.FormattingEnabled = true;
            this.lbPermisos.Location = new System.Drawing.Point(36, 696);
            this.lbPermisos.Name = "lbPermisos";
            this.lbPermisos.Size = new System.Drawing.Size(178, 316);
            this.lbPermisos.TabIndex = 1;
            this.lbPermisos.Visible = false;
            // 
            // btnBackup
            // 
            this.btnBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBackup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBackup.Depth = 0;
            this.btnBackup.HighEmphasis = true;
            this.btnBackup.Icon = null;
            this.btnBackup.Location = new System.Drawing.Point(36, 632);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBackup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBackup.Size = new System.Drawing.Size(284, 36);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "Crear Backup de la Base de datos";
            this.btnBackup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBackup.UseAccentColor = false;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRestore.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRestore.Depth = 0;
            this.btnRestore.HighEmphasis = true;
            this.btnRestore.Icon = null;
            this.btnRestore.Location = new System.Drawing.Point(374, 632);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRestore.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRestore.Size = new System.Drawing.Size(217, 36);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restaurar Base de Datos";
            this.btnRestore.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRestore.UseAccentColor = false;
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // lblrm
            // 
            this.lblrm.AutoSize = true;
            this.lblrm.Depth = 0;
            this.lblrm.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblrm.Location = new System.Drawing.Point(347, 536);
            this.lblrm.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblrm.Name = "lblrm";
            this.lblrm.Size = new System.Drawing.Size(141, 19);
            this.lblrm.TabIndex = 4;
            this.lblrm.Text = "RESERVA POR MES";
            this.lblrm.Visible = false;
            // 
            // lblrth
            // 
            this.lblrth.AutoSize = true;
            this.lblrth.Depth = 0;
            this.lblrth.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblrth.Location = new System.Drawing.Point(1121, 536);
            this.lblrth.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblrth.Name = "lblrth";
            this.lblrth.Size = new System.Drawing.Size(262, 19);
            this.lblrth.TabIndex = 5;
            this.lblrth.Text = "RESERVA POR TIPO DE HABITACION";
            this.lblrth.Visible = false;
            // 
            // opcionesDeReservaToolStripMenuItem
            // 
            this.opcionesDeReservaToolStripMenuItem.Name = "opcionesDeReservaToolStripMenuItem";
            this.opcionesDeReservaToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.opcionesDeReservaToolStripMenuItem.Text = "Opciones de Reserva";
            this.opcionesDeReservaToolStripMenuItem.Click += new System.EventHandler(this.opcionesDeReservaToolStripMenuItem_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1878, 1100);
            this.Controls.Add(this.lblrth);
            this.Controls.Add(this.lblrm);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.cartesianChart2);
            this.Controls.Add(this.lbPermisos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mi Hostal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeHabitacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ListBox lbPermisos;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private MaterialSkin.Controls.MaterialButton btnBackup;
        private MaterialSkin.Controls.MaterialButton btnRestore;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private MaterialSkin.Controls.MaterialLabel lblrm;
        private MaterialSkin.Controls.MaterialLabel lblrth;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesDeReservaToolStripMenuItem;
    }
}