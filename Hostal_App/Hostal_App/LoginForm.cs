using Hostal_App.Services;
using System;
using System.Windows.Forms;

namespace Hostal_App
{
    public partial class LoginForm : Form
    {
        private readonly LoginService loginService;
        private readonly GrupoService grupoService;

        public LoginForm()
        {
            InitializeComponent();
            loginService = new LoginService();
            grupoService = new GrupoService();
            CargarComboBoxGrupos();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPass.Text;
            int grupoId = (int)cmbGrupos.SelectedValue;

            try
            {
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password) || grupoId <=0)
                {
                    MessageBox.Show("¡Algun campo vacío o grupo no seleccionado! Verifique por favor", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Clear();
                    txtPass.Clear();
                    cmbGrupos.SelectedValue = -1;
                    txtUsuario.Focus();
                    return;
                }


                // Autenticar usuario
                bool autenticado = loginService.AutenticarUsuario(usuario, password, grupoId);

                if (autenticado)
                {
                    // Obtener permisos del usuario y realizar otras acciones
                    var permisos = grupoService.ObtenerPermisosPorGrupo(grupoId);

                    MessageBox.Show("¡Inicio de sesión exitoso!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide(); // Ocultar el formulario de login
                    Dashboard dashboardForm = new Dashboard(permisos);
                    dashboardForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas. Por favor, inténtalo de nuevo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboBoxGrupos()
        { 
            cmbGrupos.DataSource = grupoService.ObtenerGrupos();
            cmbGrupos.DisplayMember = "nombre";
            cmbGrupos.ValueMember = "Id";
            cmbGrupos.SelectedIndex = -1;
        }
    }
}
