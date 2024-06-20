using Hostal_App.Helper;
using Hostal_App.Services;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Hostal_App
{
    public partial class LoginForm : Form
    {
        private readonly LoginService loginService;

        public LoginForm()
        {
            InitializeComponent();
            loginService = new LoginService();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPass.Text;

            try
            {
                // Verificar si los campos están vacíos
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("¡Usuario o Contraseña vacíos!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Clear();
                    txtPass.Clear();
                    txtUsuario.Focus();
                    return; // Salir del método para evitar la autenticación con campos vacíos
                }

                if (loginService.AutenticarUsuario(usuario, password))
                {
                    // Autenticación exitosa, puedes redirigir a la siguiente pantalla o realizar otras acciones
                    MessageBox.Show("¡Inicio de sesión exitoso!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide(); // Ocultar el formulario de login
                    Dashboard dashboardForm = new Dashboard();
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
    }
}
