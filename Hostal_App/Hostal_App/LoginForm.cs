using Hostal_App.Services;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Hostal_App
{
    public partial class LoginForm : MaterialForm
    {
        private readonly LoginService loginService;
        private readonly GrupoService grupoService;
        private readonly ErrorProvider errorProvider;

        public LoginForm()
        {
            InitializeComponent();
            loginService = new LoginService();
            grupoService = new GrupoService();
            errorProvider = new ErrorProvider();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Limpiar errores antes de validar
            errorProvider.Clear();
            string usuario = txtUsuario.Text;
            string password = txtPass.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {


                    // Autenticar usuario
                    bool autenticado = loginService.AutenticarUsuario(usuario, password);

                    if (autenticado)
                    {
                        // Obtener permisos del usuario y realizar otras acciones
                        var permisos = grupoService.ObtenerPermisosPorUsuario(usuario);
                        int grupoId = grupoService.ObtenerGrupoIDPorUsuario(usuario);
                        MessageBox.Show("¡Inicio de sesión exitoso!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide(); // Ocultar el formulario de login
                                     // Mostrar el formulario principal
                        DashboardForm dashboardForm = new DashboardForm(permisos,grupoId);
                        dashboardForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas. Por favor, inténtalo de nuevo.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // Métodos de validación
        private void TxtUsuario_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtUsuario, "El nombre de usuario es obligatorio.");
            }
            else
            {
                errorProvider.SetError(txtUsuario, string.Empty);
            }
        }

        private void TxtPass_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPass, "La contraseña es obligatoria.");
            }
            else
            {
                errorProvider.SetError(txtPass, string.Empty);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
